﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
using NuGet.Services.Metadata.Catalog.Persistence;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using VDS.RDF;

namespace NuGet.Services.Metadata.Catalog
{
    public class RegistrationCatalogCollector : SortingGraphCollector
    {
        StorageFactory _storageFactory;

        public RegistrationCatalogCollector(Uri index, StorageFactory storageFactory, Func<HttpMessageHandler> handlerFunc = null)
            : base(index, new Uri[] { Schema.DataTypes.PackageDetails, Schema.DataTypes.PackageDelete }, handlerFunc)
        {
            _storageFactory = storageFactory;

            ContentBaseAddress = new Uri("http://tempuri.org");

            PartitionSize = 64;
            PackageCountThreshold = 128;
        }

        public Uri ContentBaseAddress { get; set; }
        public int PartitionSize { get; set; }
        public int PackageCountThreshold { get; set; }

        protected override Task ProcessGraphs(KeyValuePair<string, IDictionary<string, IGraph>> sortedGraphs, CancellationToken cancellationToken)
        {
            return RegistrationCatalogCreator.ProcessGraphs(
                sortedGraphs.Key,
                sortedGraphs.Value,
                _storageFactory,
                ContentBaseAddress,
                PartitionSize,
                PackageCountThreshold, cancellationToken);
        }
    }
}
