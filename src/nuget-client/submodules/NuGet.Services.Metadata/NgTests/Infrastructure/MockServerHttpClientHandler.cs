// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace NgTests.Infrastructure
{
    public class MockServerHttpClientHandler
        : HttpClientHandler
    {
        public Dictionary<string, Func<HttpRequestMessage, Task<HttpResponseMessage>>> Actions { get; private set; }
        public bool Return404OnUnknownAction { get; set; }

        public MockServerHttpClientHandler()
        {
            Actions = new Dictionary<string, Func<HttpRequestMessage, Task<HttpResponseMessage>>>();
            Return404OnUnknownAction = true;
        }

        public void SetAction(string relativeUrl, Func<HttpRequestMessage, Task<HttpResponseMessage>> action)
        {
            Actions[relativeUrl] = action;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Func<HttpRequestMessage, Task<HttpResponseMessage>> action;
            if (Actions.TryGetValue(request.RequestUri.PathAndQuery, out action))
            {
                return await action(request);
            }

            if (Return404OnUnknownAction)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("Could not find " + request.RequestUri)
                };
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}