﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json.Linq;
using PublishTestDriverWebSite.Models;
using PublishTestDriverWebSite.Utils;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PublishTestDriverWebSite.Controllers
{
    [Authorize]
    public class TenantController : Controller
    {
        private string nugetServiceResourceId = ConfigurationManager.AppSettings["nuget:ServiceResourceId"];
        private string nugetPublishServiceBaseAddress = ConfigurationManager.AppSettings["nuget:PublishServiceBaseAddress"];
        private const string TenantIdClaimType = "http://schemas.microsoft.com/identity/claims/tenantid";
        private static string clientId = ConfigurationManager.AppSettings["ida:ClientId"];
        private static string appKey = ConfigurationManager.AppSettings["ida:AppKey"];

        // GET: Tenant
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public Task<ActionResult> Add()
        {
            return Send("add");
        }

        [HttpPost]
        public Task<ActionResult> Remove()
        {
            return Send("remove");
        }

        async Task<ActionResult> Send(string action)
        {
            var signedInUserId = ClaimsPrincipal.Current.FindFirst(ClaimTypes.NameIdentifier).Value;
            var userObjectIdClaim = ClaimsPrincipal.Current.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier");
            var userObjectId = userObjectIdClaim != null ? userObjectIdClaim.Value : signedInUserId;

            string tenantId = ClaimsPrincipal.Current.FindFirst("http://schemas.microsoft.com/identity/claims/tenantid").Value;

            string authority = string.Format(Startup.AuthorityFormat, tenantId);

            AuthenticationContext authContext = new AuthenticationContext(authority, new NaiveSessionCache(signedInUserId));

            AuthenticationResult authenticationResult;

            if (Startup.Certificate == null)
            {
                ClientCredential credential = new ClientCredential(clientId, appKey);
                authenticationResult = await authContext.AcquireTokenSilentAsync(nugetServiceResourceId, credential, new UserIdentifier(userObjectId, UserIdentifierType.UniqueId));
            }
            else
            {
                ClientAssertionCertificate clientAssertionCertificate = new ClientAssertionCertificate(clientId, Startup.Certificate);
                authenticationResult = await authContext.AcquireTokenSilentAsync(nugetServiceResourceId, clientAssertionCertificate, new UserIdentifier(userObjectId, UserIdentifierType.UniqueId));
            }

            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, nugetPublishServiceBaseAddress.TrimEnd('/') + "/tenant/" + action);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authenticationResult.AccessToken);

            HttpResponseMessage response = await client.SendAsync(request);

            string message = null;
            if (response.IsSuccessStatusCode)
            {
                message = "OK";
            }
            else
            {
                JObject publishServiceResponse = JObject.Parse(await response.Content.ReadAsStringAsync());
                message = string.Format("ERROR: {0}", publishServiceResponse["error"].ToString());
            }

            return View(new TenantModel { Message = message });
        }
    }
}