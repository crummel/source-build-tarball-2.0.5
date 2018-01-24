﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Microsoft.Owin.StaticFiles.Infrastructure;
using NuGet.Indexing;
using Owin;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Lucene.Net.Store;
using Microsoft.Extensions.Logging;

[assembly: OwinStartup("NuGet.Services.BasicSearch", typeof(NuGet.Services.BasicSearch.Startup))]

namespace NuGet.Services.BasicSearch
{
    public class Startup
    {
        private ILogger _logger;
        private Timer _timer;
        private NuGetSearcherManager _searcherManager;
        private int _gate;

        public void Configuration(IAppBuilder app, IConfiguration configuration, Directory directory, ILoader loader)
        {
            // create an ILoggerFactory
            var loggerFactory = Logging.CreateLoggerFactory();

            // create a logger that is scoped to this class (only)
            _logger = loggerFactory.CreateLogger<Startup>();

            //  search test console
            app.Use(async (context, next) =>
            {
                if (string.Equals(context.Request.Path.Value, "/console", StringComparison.OrdinalIgnoreCase))
                {
                    // Redirect to trailing slash to maintain relative links
                    context.Response.Redirect(context.Request.PathBase + context.Request.Path + "/");
                    context.Response.StatusCode = 301;
                    return;
                }
                else if (string.Equals(context.Request.Path.Value, "/console/", StringComparison.OrdinalIgnoreCase))
                {
                    context.Request.Path = new PathString("/console/Index.html");
                }
                await next();
            });

            app.UseStaticFiles(new StaticFileOptions(new SharedOptions
            {
                RequestPath = new PathString("/console"),
                FileSystem = new EmbeddedResourceFileSystem(typeof(Startup).Assembly, "NuGet.Services.BasicSearch.Console")
            }));

            //  start the service running - the Lucene index needs to be reopened regularly on a background thread
            string searchIndexRefresh = configuration.Get("Search.IndexRefresh") ?? "15";
            int seconds;
            if (!int.TryParse(searchIndexRefresh, out seconds))
            {
                seconds = 120;
            }

            _logger.LogInformation(
                "Search service is configured to refresh the index every {SearchIndexRefresh} seconds", seconds);

            if (InitializeSearcherManager(configuration, directory, loader, loggerFactory))
            {
                _gate = 0;
                _timer = new Timer(ReopenCallback, 0, 0, seconds * 1000);
            }

            app.Run(Invoke);
        }

        public void Configuration(IAppBuilder app)
        {
            Configuration(app, new ConfigurationService(), null, null);
        }

        void ReopenCallback(object state)
        {
            try
            {
                int val = Interlocked.Increment(ref _gate);
                if (val > 1)
                {
                    _logger.LogInformation("Search index is already being reopened so thread ID {ThreadId} will not try to reopen the index again", Thread.CurrentThread.ManagedThreadId);
                    Interlocked.Decrement(ref _gate);
                    return;
                }

                _logger.LogInformation("Beginning to reopen the search index on thread ID {ThreadId}", Thread.CurrentThread.ManagedThreadId);
                var stopwatch = Stopwatch.StartNew();
                _searcherManager.MaybeReopen();
                _logger.LogInformation("Reopening the search index took {ElapsedSeconds} seconds on thread ID {ThreadId}", stopwatch.Elapsed.TotalSeconds, Thread.CurrentThread.ManagedThreadId);

                Interlocked.Decrement(ref _gate);
            }
            catch (Exception e)
            {
                ServiceHelpers.TraceException(e, _logger);
            }
        }

        bool InitializeSearcherManager(IConfiguration configuration, Directory directory, ILoader loader, ILoggerFactory loggerFactory)
        {
            try
            {
                _searcherManager = NuGetSearcherManager.Create(configuration, loggerFactory, directory, loader);
                _searcherManager.Open();
                return true;
            }
            catch (Exception e)
            {
                ServiceHelpers.TraceException(e, _logger);
                return false;
            }
        }

        public async Task Invoke(IOwinContext context)
        {
            try
            {
                if (_searcherManager == null)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    await context.Response.WriteAsync("UNINITIALIZED");
                }
                else
                {
                    switch (context.Request.Path.Value)
                    {
                        case "/":
                            context.Response.StatusCode = (int)HttpStatusCode.OK;
                            await context.Response.WriteAsync("READY");
                            break;
                        case "/find":
                            await ServiceEndpoints.FindAsync(context, _searcherManager);
                            break;
                        case "/query":
                            await ServiceEndpoints.V3SearchAsync(context, _searcherManager);
                            break;
                        case "/autocomplete":
                            await ServiceEndpoints.AutoCompleteAsync(context, _searcherManager);
                            break;
                        case "/search/query":
                            await ServiceEndpoints.V2SearchAsync(context, _searcherManager);
                            break;
                        case "/rankings":
                            await ServiceEndpoints.RankingsAsync(context, _searcherManager);
                            break;
                        case "/search/diag":
                            await ServiceEndpoints.Stats(context, _searcherManager);
                            break;
                        default:
                            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                            await context.Response.WriteAsync("UNRECOGNIZED");
                            break;
                    }
                }
            }
            catch (ClientException e)
            {
                await ResponseHelpers.WriteResponseAsync(context, e);
            }
            catch (Exception e)
            {
                await ResponseHelpers.WriteResponseAsync(context, e, _logger);
            }
        }
    }
}
