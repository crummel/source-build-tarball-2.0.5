﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NuGet.Services.Metadata.Catalog.Persistence
{
    public class AzureStorage : Storage
    {
        private CloudBlobDirectory _directory;

        public AzureStorage(CloudStorageAccount account, string containerName)
            : this(account, containerName, String.Empty) { }

        public AzureStorage(CloudStorageAccount account, string containerName, string path, Uri baseAddress)
            : this(account.CreateCloudBlobClient().GetContainerReference(containerName).GetDirectoryReference(path), baseAddress)
        {
        }

        public AzureStorage(CloudStorageAccount account, string containerName, string path)
            : this(account.CreateCloudBlobClient().GetContainerReference(containerName).GetDirectoryReference(path))
        {
        }

        public AzureStorage(CloudBlobDirectory directory)
            : this(directory, GetDirectoryUri(directory))
        {
        }

        public AzureStorage(CloudBlobDirectory directory, Uri baseAddress)
            : base(baseAddress ?? GetDirectoryUri(directory))
        {
            _directory = directory;

            if (_directory.Container.CreateIfNotExists())
            {
                _directory.Container.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

                if (Verbose)
                {
                    Trace.WriteLine(String.Format("Created '{0}' publish container", _directory.Container.Name));
                }
            }

            ResetStatistics();
        }

        static Uri GetDirectoryUri(CloudBlobDirectory directory)
        {
            Uri uri = new UriBuilder(directory.Uri)
            {
                Scheme = "http",
                Port = 80
            }.Uri;

            return uri;
        }

        //Blob exists
        public override bool Exists(string fileName)
        {
            Uri packageRegistrationUri = ResolveUri(fileName);
            string blobName = GetName(packageRegistrationUri);

            CloudBlockBlob blob = _directory.GetBlockBlobReference(blobName);

            if (blob.Exists())
            {
                return true;
            }
            return false;
        }

        public override async Task<IEnumerable<Uri>> List(CancellationToken cancellationToken)
        {
            var files = await _directory.ListBlobsAsync(cancellationToken);

            return files.Select(file => file.Uri).AsEnumerable();
        }

        //  save

        protected override async Task OnSave(Uri resourceUri, StorageContent content, CancellationToken cancellationToken)
        {
            string name = GetName(resourceUri);

            CloudBlockBlob blob = _directory.GetBlockBlobReference(name);
            blob.Properties.ContentType = content.ContentType;
            blob.Properties.CacheControl = content.CacheControl;

            using (Stream stream = content.GetContentStream())
            {
                await blob.UploadFromStreamAsync(stream, cancellationToken);
            }
        }

        //  load

        protected override async Task<StorageContent> OnLoad(Uri resourceUri, CancellationToken cancellationToken)
        {
            // the Azure SDK will treat a starting / as an absolute URL,
            // while we may be working in a subdirectory of a storage container
            // trim the starting slash to treat it as a relative path
            string name = GetName(resourceUri).TrimStart('/');

            CloudBlockBlob blob = _directory.GetBlockBlobReference(name);

            if (blob.Exists())
            {
                string content = await blob.DownloadTextAsync(cancellationToken);
                return new StringStorageContent(content);
            }

            return null;
        }

        //  delete

        protected override async Task OnDelete(Uri resourceUri, CancellationToken cancellationToken)
        {
            string name = GetName(resourceUri);

            CloudBlockBlob blob = _directory.GetBlockBlobReference(name);

            await blob.DeleteAsync(cancellationToken);
        }
    }
}
