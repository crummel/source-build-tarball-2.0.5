﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Lucene.Net.Documents;
using Lucene.Net.Search;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NuGet.Indexing
{
    public static class ResponseFormatter
    {
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //
        // V3 implementation - called directly from the integrated Visual Studio client
        //
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void WriteSearchResult(JsonWriter jsonWriter, NuGetIndexSearcher searcher, string scheme, TopDocs topDocs, int skip, int take, bool includePrerelease, bool includeExplanation, Query query)
        {
            Uri baseAddress = searcher.Manager.RegistrationBaseAddress[scheme];

            jsonWriter.WriteStartObject();
            WriteInfo(jsonWriter, baseAddress, searcher, topDocs);
            WriteData(jsonWriter, searcher, topDocs, skip, take, baseAddress, includePrerelease, includeExplanation, query);
            jsonWriter.WriteEndObject();
        }

        private static void WriteInfo(JsonWriter jsonWriter, Uri baseAddress, NuGetIndexSearcher searcher, TopDocs topDocs)
        {
            WriteContext(jsonWriter, baseAddress);
            WriteProperty(jsonWriter, "totalHits", topDocs.TotalHits);
            WriteProperty(jsonWriter, "lastReopen", searcher.LastReopen.ToString("o"));
            WriteProperty(jsonWriter, "index", searcher.Manager.IndexName);
        }

        private static void WriteContext(JsonWriter jsonWriter, Uri baseAddress)
        {
            jsonWriter.WritePropertyName("@context");
        
            jsonWriter.WriteStartObject();
            WriteProperty(jsonWriter, "@vocab", "http://schema.nuget.org/schema#");
            if (baseAddress != null)
            {
                WriteProperty(jsonWriter, "@base", baseAddress.AbsoluteUri);
            }
            jsonWriter.WriteEndObject();
        }

        private static void WriteData(JsonWriter jsonWriter, NuGetIndexSearcher searcher, TopDocs topDocs, int skip, int take, Uri baseAddress, bool includePrerelease, bool includeExplanation, Query query)
        {
            jsonWriter.WritePropertyName("data");

            jsonWriter.WriteStartArray();

            for (int i = skip; i < Math.Min(skip + take, topDocs.ScoreDocs.Length); i++)
            {
                ScoreDoc scoreDoc = topDocs.ScoreDocs[i];

                Document document = searcher.Doc(scoreDoc.Doc);               

                jsonWriter.WriteStartObject();
                
                string id = document.Get("Id");

                string relativeAddress = UriFormatter.MakeRegistrationRelativeAddress(id);

                WriteProperty(jsonWriter, "@id", relativeAddress);
                WriteProperty(jsonWriter, "@type", "Package");
                WriteProperty(jsonWriter, "registration", new Uri(baseAddress, relativeAddress).AbsoluteUri);

                WriteProperty(jsonWriter, "id", id);

                WriteDocumentValue(jsonWriter, "version", document, "Version");
                WriteDocumentValue(jsonWriter, "description", document, "Description");
                WriteDocumentValue(jsonWriter, "summary", document, "Summary");
                WriteDocumentValue(jsonWriter, "title", document, "Title");
                WriteDocumentValue(jsonWriter, "iconUrl", document, "IconUrl");
                WriteDocumentValue(jsonWriter, "licenseUrl", document, "LicenseUrl");
                WriteDocumentValue(jsonWriter, "projectUrl", document, "ProjectUrl");
                WriteDocumentValueAsArray(jsonWriter, "tags", document, "Tags");
                WriteDocumentValueAsArray(jsonWriter, "authors", document, "Authors", true);
                WriteProperty(jsonWriter, "totalDownloads", searcher.Versions[scoreDoc.Doc].VersionDetails.Select(item => item.Downloads).Sum());
                WriteVersions(jsonWriter, id, includePrerelease, searcher.Versions[scoreDoc.Doc]);

                if (includeExplanation)
                {
                    Explanation explanation = searcher.Explain(query, scoreDoc.Doc);
                    WriteProperty(jsonWriter, "explanation", explanation.ToString());
                }

                jsonWriter.WriteEndObject();
            }

            jsonWriter.WriteEndArray();
        }

        private static void WriteVersions(JsonWriter jsonWriter, string id, bool includePrerelease, VersionsHandler.VersionResult versionResult)
        {
            jsonWriter.WritePropertyName("versions");

            jsonWriter.WriteStartArray();

            foreach (var item in includePrerelease ? versionResult.VersionDetails : versionResult.StableVersionDetails)
            {
                jsonWriter.WriteStartObject();

                WriteProperty(jsonWriter, "version", item.Version);
                WriteProperty(jsonWriter, "downloads", item.Downloads);
                WriteProperty(jsonWriter, "@id", UriFormatter.MakePackageRelativeAddress(id, item.Version));

                jsonWriter.WriteEndObject();
            }

            jsonWriter.WriteEndArray();
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //
        // V3 auto-complete implementation - called from the Visual Studio "project.json editor"
        //
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void WriteAutoCompleteResult(JsonWriter jsonWriter, NuGetIndexSearcher searcher, TopDocs topDocs, int skip, int take, bool includeExplanation, Query query)
        {
            jsonWriter.WriteStartObject();
            WriteInfo(jsonWriter, null, searcher, topDocs);
            WriteIds(jsonWriter, searcher, topDocs, skip, take);
                    
            if (includeExplanation)
            {
                WriteExplanations(jsonWriter, searcher, topDocs, skip, take, query);
            }
                    
            jsonWriter.WriteEndObject();
        }

        public static void WriteAutoCompleteVersionResult(JsonWriter jsonWriter, NuGetIndexSearcher searcher, bool includePrerelease, TopDocs topDocs)
        {
            jsonWriter.WriteStartObject();
            WriteInfo(jsonWriter, null, searcher, topDocs);
            WriteVersions(jsonWriter, searcher, includePrerelease, topDocs);
            jsonWriter.WriteEndObject();
        }

        private static void WriteIds(JsonWriter jsonWriter, NuGetIndexSearcher searcher, TopDocs topDocs, int skip, int take)
        {
            jsonWriter.WritePropertyName("data");
            jsonWriter.WriteStartArray();
            for (int i = skip; i < Math.Min(skip + take, topDocs.ScoreDocs.Length); i++)
            {
                ScoreDoc scoreDoc = topDocs.ScoreDocs[i];
                Document document = searcher.Doc(scoreDoc.Doc);
                string id = document.Get("Id");
                jsonWriter.WriteValue(id);
            }
            jsonWriter.WriteEndArray();
        }

        private static void WriteExplanations(JsonWriter jsonWriter, NuGetIndexSearcher searcher, TopDocs topDocs, int skip, int take, Query query)
        {
            jsonWriter.WritePropertyName("explanations");
            jsonWriter.WriteStartArray();
            for (int i = skip; i < Math.Min(skip + take, topDocs.ScoreDocs.Length); i++)
            {
                ScoreDoc scoreDoc = topDocs.ScoreDocs[i];
                Explanation explanation = searcher.Explain(query, scoreDoc.Doc);
                jsonWriter.WriteValue(explanation.ToString());
            }
            jsonWriter.WriteEndArray();
        }

        private static void WriteVersions(JsonWriter jsonWriter, NuGetIndexSearcher searcher, bool includePrerelease, TopDocs topDocs)
        {
            jsonWriter.WritePropertyName("data");
            jsonWriter.WriteStartArray();

            if (topDocs.TotalHits > 0)
            {
                ScoreDoc scoreDoc = topDocs.ScoreDocs[0];

                var versions = includePrerelease ? searcher.Versions[scoreDoc.Doc].Versions : searcher.Versions[scoreDoc.Doc].StableVersions;

                foreach (var version in versions)
                {
                    jsonWriter.WriteValue(version);
                }
            }

            jsonWriter.WriteEndArray();
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //
        // V3 find implementation
        //
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void WriteFindResult(JsonWriter jsonWriter, NuGetIndexSearcher searcher, string scheme, TopDocs topDocs)
        {
            Uri baseAddress = searcher.Manager.RegistrationBaseAddress[scheme];

            jsonWriter.WriteStartObject();
            WriteInfo(jsonWriter, null, searcher, topDocs);

            if (topDocs.TotalHits > 0)
            {
                ScoreDoc scoreDoc = topDocs.ScoreDocs[0];
                Document document = searcher.Doc(scoreDoc.Doc);
                string id = document.Get("Id");

                string relativeAddress = UriFormatter.MakeRegistrationRelativeAddress(id); 

                WriteProperty(jsonWriter, "registration", new Uri(baseAddress, relativeAddress).AbsoluteUri);
            }

            jsonWriter.WriteEndObject();
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //
        // V2 search implementation - called from the NuGet Gallery
        //
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static void WriteV2Result(JsonWriter jsonWriter, NuGetIndexSearcher searcher, TopDocs topDocs, int skip, int take)
        {
            jsonWriter.WriteStartObject();
            WriteInfoV2(jsonWriter, searcher, topDocs);
            WriteDataV2(jsonWriter, searcher, topDocs, skip, take);
            jsonWriter.WriteEndObject();
        }

        public static void WriteV2CountResult(JsonWriter jsonWriter, int totalHits)
        {
            jsonWriter.WriteStartObject();
            WriteProperty(jsonWriter, "totalHits", totalHits);
            jsonWriter.WriteEndObject();
        }

        private static void WriteInfoV2(JsonWriter jsonWriter, NuGetIndexSearcher searcher, TopDocs topDocs)
        {
            WriteProperty(jsonWriter, "totalHits", topDocs.TotalHits);

            string timestamp;
            DateTime dt;
            if (searcher.CommitUserData.TryGetValue("commitTimeStamp", out timestamp) &&
                DateTime.TryParse(timestamp, out dt))
            {
                timestamp = dt.ToUniversalTime().ToString("G");
            }
            else
            {
                timestamp = DateTime.MinValue.ToUniversalTime().ToString("G");
            }

            // TODO: can we find this value?
            // WriteProperty(jsonWriter, "timeTakenInMs", 0);
            WriteProperty(jsonWriter, "index", searcher.Manager.IndexName);

            // CommittimeStamp format: 2015-10-12T18:39:39.6830871Z
            // Time format in V2: 10/22/2015 4:53:25 PM
            WriteProperty(jsonWriter, "indexTimestamp", timestamp);
        }

        private static void WriteRegistrationV2(JsonWriter jsonWriter, Document document, int downloadCount)
        {
            jsonWriter.WritePropertyName("PackageRegistration");
            jsonWriter.WriteStartObject();
            
            WriteDocumentValue(jsonWriter, "Id", document, "Id");
            WriteProperty(jsonWriter, "DownloadCount", downloadCount);
            
            jsonWriter.WritePropertyName("Owners");
            jsonWriter.WriteStartArray();
            foreach (string owner in document.GetValues("Owner"))
            {
                jsonWriter.WriteValue(owner);
            }
            jsonWriter.WriteEndArray();
            
            jsonWriter.WriteEndObject();
        }

        private static void WriteDataV2(JsonWriter jsonWriter, NuGetIndexSearcher searcher, TopDocs topDocs, int skip, int take)
        {
            jsonWriter.WritePropertyName("data");

            jsonWriter.WriteStartArray();

            for (int i = skip; i < Math.Min(skip + take, topDocs.ScoreDocs.Length); i++)
            {
                ScoreDoc scoreDoc = topDocs.ScoreDocs[i];
                Document document = searcher.Doc(scoreDoc.Doc);

                string version = document.Get("Version");

                Tuple<int, int> downloadCounts = NuGetIndexSearcher.GetDownloadCounts(searcher.Versions[scoreDoc.Doc], version);

                bool isLatest = searcher.LatestBitSet.Get(scoreDoc.Doc);
                bool isLatestStable = searcher.LatestStableBitSet.Get(scoreDoc.Doc);

                jsonWriter.WriteStartObject();
                WriteRegistrationV2(jsonWriter, document, downloadCounts.Item1);
                WriteDocumentValue(jsonWriter, "Version", document, "OriginalVersion");
                WriteProperty(jsonWriter, "NormalizedVersion", version);
                WriteDocumentValue(jsonWriter, "Title", document, "Title");
                WriteDocumentValue(jsonWriter, "Description", document, "Description");
                WriteDocumentValue(jsonWriter, "Summary", document, "Summary");
                WriteDocumentValue(jsonWriter, "Authors", document, "Authors");
                WriteDocumentValue(jsonWriter, "Copyright", document, "Copyright");
                WriteDocumentValue(jsonWriter, "Language", document, "Language");
                WriteDocumentValue(jsonWriter, "Tags", document, "Tags");
                WriteDocumentValue(jsonWriter, "ReleaseNotes", document, "ReleaseNotes");
                WriteDocumentValue(jsonWriter, "ProjectUrl", document, "ProjectUrl");
                WriteDocumentValue(jsonWriter, "IconUrl", document, "IconUrl");
                WriteProperty(jsonWriter, "IsLatestStable", isLatestStable);
                WriteProperty(jsonWriter, "IsLatest", isLatest);
                WriteProperty(jsonWriter, "Listed", bool.Parse(document.Get("Listed") ?? "true"));
                WriteDocumentValue(jsonWriter, "Created", document, "OriginalCreated");
                WriteDocumentValue(jsonWriter, "Published", document, "OriginalPublished");
                WriteDocumentValue(jsonWriter, "LastUpdated", document, "OriginalPublished");
                WriteDocumentValue(jsonWriter, "LastEdited", document, "OriginalLastEdited");
                WriteProperty(jsonWriter, "DownloadCount", downloadCounts.Item2);
                WriteDocumentValue(jsonWriter, "FlattenedDependencies", document, "FlattenedDependencies");
                jsonWriter.WritePropertyName("Dependencies");
                jsonWriter.WriteRawValue(document.Get("Dependencies") ?? "[]");
                jsonWriter.WritePropertyName("SupportedFrameworks");
                jsonWriter.WriteRawValue(document.Get("SupportedFrameworks") ?? "[]");
                WriteDocumentValue(jsonWriter, "MinClientVersion", document, "MinClientVersion");
                WriteDocumentValue(jsonWriter, "Hash", document, "PackageHash");
                WriteDocumentValue(jsonWriter, "HashAlgorithm", document, "PackageHashAlgorithm");
                WriteProperty(jsonWriter, "PackageFileSize", int.Parse(document.Get("PackageSize") ?? "0"));
                WriteDocumentValue(jsonWriter, "LicenseUrl", document, "LicenseUrl");
                WriteProperty(jsonWriter, "RequiresLicenseAcceptance", bool.Parse(document.Get("RequiresLicenseAcceptance") ?? "true"));
                jsonWriter.WriteEndObject();
            }

            jsonWriter.WriteEndArray();
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Diagnostic responses
        //
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void WriteStatsResult(JsonWriter jsonWriter, NuGetIndexSearcher searcher)
        {
            jsonWriter.WriteStartObject();
            WriteProperty(jsonWriter, "numDocs", searcher.IndexReader.NumDocs());
            WriteProperty(jsonWriter, "indexName", searcher.Manager.IndexName);
            WriteProperty(jsonWriter, "lastReopen", searcher.LastReopen);

            jsonWriter.WritePropertyName("CommitUserData");
            jsonWriter.WriteStartObject();
            foreach (var userData in searcher.CommitUserData)
            {
                WriteProperty(jsonWriter, userData.Key, userData.Value);
            }

            jsonWriter.WriteEndObject();
            jsonWriter.WriteEndObject();
        }

        public static void WriteRankingsResult(JsonWriter jsonWriter, IDictionary<string, int> rankings)
        {
            jsonWriter.WriteStartObject();
            jsonWriter.WritePropertyName("rankings");
            jsonWriter.WriteStartArray();
            foreach (var ranking in rankings)
            {
                jsonWriter.WriteStartObject();
                jsonWriter.WritePropertyName("id");
                jsonWriter.WriteValue(ranking.Key);
                jsonWriter.WritePropertyName("Rank");
                jsonWriter.WriteValue(ranking.Value);
                jsonWriter.WriteEndObject();
            }
            jsonWriter.WriteEndArray();
            jsonWriter.WriteEndObject();
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //
        // various generic helpers for building JSON results from Lucene Documents
        //
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private static void WriteProperty<T>(JsonWriter jsonWriter, string propertyName, T value)
        {
            jsonWriter.WritePropertyName(propertyName);
            jsonWriter.WriteValue(value);
        }

        private static void WriteDocumentValue(JsonWriter jsonWriter, string propertyName, Document document, string fieldName)
        {
            string value = document.Get(fieldName);
            if (value != null)
            {
                WriteProperty(jsonWriter, propertyName, value);
            }
        }

        private static void WriteDocumentValueAsArray(JsonWriter jsonWriter, string propertyName, Document document, string fieldName, bool singleElement = false)
        {
            string value = document.Get(fieldName);
            if (value != null)
            {
                jsonWriter.WritePropertyName(propertyName);
                jsonWriter.WriteStartArray();

                if (singleElement)
                {
                    jsonWriter.WriteValue(value);
                }
                else
                {
                    foreach (var s in value.Split(new[]{' ', ','}, StringSplitOptions.RemoveEmptyEntries))
                    {
                        jsonWriter.WriteValue(s);
                    }
                }

                jsonWriter.WriteEndArray();
            }
        }
    }
}
