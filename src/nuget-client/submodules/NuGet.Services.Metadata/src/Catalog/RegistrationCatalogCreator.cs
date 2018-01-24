﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
using Newtonsoft.Json.Linq;
using NuGet.Services.Metadata.Catalog.Helpers;
using NuGet.Services.Metadata.Catalog.Persistence;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VDS.RDF;
using VDS.RDF.Query;

namespace NuGet.Services.Metadata.Catalog
{
    public static class RegistrationCatalogCreator
    {
        static List<string> existingVersionsWithID;

         public static async Task ProcessGraphs(
            string id,
            IDictionary<string, IGraph> sortedGraphs,
            StorageFactory storageFactory,
            Uri contentBaseAddress,
            int partitionSize,
            int packageCountThreshold,
             CancellationToken cancellationToken)
        {
            int versionAlreadyExistsCount = 0;
            existingVersionsWithID = new List<string>();
            
            try
            {
                Storage storage = storageFactory.Create(id.ToLowerInvariant());

                Uri resourceUri = storage.ResolveUri("index.json");
                string json = await storage.LoadString(resourceUri, cancellationToken);

                int count = Utils.CountItems(json);

                //Determine if there are any versions that are existing already
                CollectorHttpClient httpClient = new CollectorHttpClient();
                foreach (var graph in sortedGraphs)
                {
                    JObject jsonContent = await httpClient.GetJObjectAsync(new Uri(graph.Key), cancellationToken);
                    string existingId = jsonContent["@id"].ToString();
                    string existingVersionWithId = existingId.Substring(existingId.LastIndexOf("/") + 1);

                    string existingVersion = jsonContent["version"].ToString() + ".json";
                    
                    //Determine if the version is actually available
                    //In Registration blobs, the format is /packageID/packageVersion.json
                    //So to check the existence of version we need to know only the version.json
                    if (storage.Exists(existingVersion))
                    {
                        //When we compare later in AddExistingItems, we need the "packageId.packageversion.json" for comparison so store it with Id
                        existingVersionsWithID.Add(existingVersionWithId);
                        versionAlreadyExistsCount++;
                    }
                }

                int total = count + sortedGraphs.Count - versionAlreadyExistsCount;

                if (total < packageCountThreshold)
                {
                    await SaveSmallRegistration(storage, storageFactory.BaseAddress, sortedGraphs, contentBaseAddress, partitionSize, cancellationToken);
                }
                else
                {
                    await SaveLargeRegistration(storage, storageFactory.BaseAddress, sortedGraphs, json, contentBaseAddress, partitionSize, cancellationToken);
                }
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Process id = {0}", id), e);
            }
        }

        static async Task SaveSmallRegistration(Storage storage, Uri registrationBaseAddress, IDictionary<string, IGraph> items, Uri contentBaseAddress, int partitionSize, CancellationToken cancellationToken)
        {
            SingleGraphPersistence graphPersistence = new SingleGraphPersistence(storage);

            await graphPersistence.Initialize(cancellationToken);

            await SaveRegistration(storage, registrationBaseAddress, items, null, graphPersistence, contentBaseAddress, partitionSize, cancellationToken);

            // now the commit has happened the graphPersistence.Graph should contain all the data

            JObject frame = (new CatalogContext()).GetJsonLdContext("context.Registration.json", graphPersistence.TypeUri);
            StorageContent content = new StringStorageContent(Utils.CreateJson(graphPersistence.Graph, frame), "application/json", "no-store");
            await storage.Save(graphPersistence.ResourceUri, content,cancellationToken);
        }

        static async Task SaveLargeRegistration(Storage storage, Uri registrationBaseAddress, IDictionary<string, IGraph> items, string existingRoot, Uri contentBaseAddress, int partitionSize, CancellationToken cancellationToken)
        {
            if (existingRoot != null)
            {
                JToken compacted = JToken.Parse(existingRoot);
                AddExistingItems(Utils.CreateGraph(compacted), items);
            }

            IList<Uri> cleanUpList = new List<Uri>();

            await SaveRegistration(storage, registrationBaseAddress, items, cleanUpList, null, contentBaseAddress, partitionSize, cancellationToken);

            // because there were multiple files some might now be irrelevant

            foreach (Uri uri in cleanUpList)
            {
                if (uri != storage.ResolveUri("index.json"))
                {
                    Console.WriteLine("DELETE: {0}", uri);
                    await storage.Delete(uri, cancellationToken);
                }
            }
        }

        static async Task SaveRegistration(Storage storage, Uri registrationBaseAddress, IDictionary<string, IGraph> items, IList<Uri> cleanUpList, SingleGraphPersistence graphPersistence, Uri contentBaseAddress, int partitionSize, CancellationToken cancellationToken)
        {
            using (RegistrationCatalogWriter writer = new RegistrationCatalogWriter(storage, partitionSize, cleanUpList, graphPersistence))
            {
                foreach (KeyValuePair<string, IGraph> item in items)
                {
                    writer.Add(new RegistrationCatalogItem(new Uri(item.Key), item.Value, contentBaseAddress, registrationBaseAddress));
                }
                await writer.Commit(DateTime.UtcNow, null, cancellationToken);
            }
        }

        static void AddExistingItems(IGraph graph, IDictionary<string, IGraph> items)
        {
            TripleStore store = new TripleStore();
            store.Add(graph, true);

            string inlinePackageSparql = Utils.GetResource("sparql.SelectInlinePackage.rq");

            SparqlResultSet rows = SparqlHelpers.Select(store, inlinePackageSparql);
            foreach (SparqlResult row in rows)
            {
                string packageUri = ((IUriNode)row["catalogPackage"]).Uri.AbsoluteUri;
                string jsonFileName = packageUri.Substring(packageUri.LastIndexOf("/") + 1);
                
                //If items already has that version, then skip it
                //Add only the new ones
                if (!existingVersionsWithID.Contains(jsonFileName))
                {
                    items[packageUri] = graph;
                }
            }
        }
    }
}
