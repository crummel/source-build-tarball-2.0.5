﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace NuGet.Services.Metadata.Catalog.Test
{
    public class DistinctPackageIdCollector : BatchCollector
    {
        public DistinctPackageIdCollector(Uri index, Func<HttpMessageHandler> handlerFunc = null, int batchSize = 200)
            : base(index, handlerFunc, batchSize)
        {
            Result = new HashSet<string>();
        }

        public HashSet<string> Result
        {
            get; private set;
        }

        protected override async Task<bool> OnProcessBatch(CollectorHttpClient client, IList<JObject> items, JObject context, CancellationToken cancellationToken)
        {
            List<Task<JObject>> tasks = new List<Task<JObject>>();

            foreach (JObject item in items)
            {
                Uri itemUri = item["@id"].ToObject<Uri>();
                tasks.Add(client.GetJObjectAsync(itemUri, cancellationToken));
            }

            await Task.WhenAll(tasks.ToArray());

            foreach (Task<JObject> task in tasks)
            {
                JObject obj = task.Result;
                Result.Add(obj["id"].ToString().ToLowerInvariant());
            }

            return true;
        }
    }
}
