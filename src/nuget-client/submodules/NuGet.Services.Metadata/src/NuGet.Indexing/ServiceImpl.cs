﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Net;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Newtonsoft.Json;

namespace NuGet.Indexing
{
    public static class ServiceImpl
    {
        public static void Search(JsonWriter jsonWriter, NuGetSearcherManager searcherManager, string scheme, string q, bool includePrerelease, int skip, int take, string feed, bool includeExplanation)
        {
            var searcher = searcherManager.Get();
            try
            {
                Query query = MakeSearchQuery(q, searcher.Rankings);
                TopDocs topDocs;

                Filter filter = searcher.GetFilter(false, includePrerelease, feed);

                topDocs = searcher.Search(query, filter, skip + take);

                ResponseFormatter.WriteSearchResult(jsonWriter, searcher, scheme, topDocs, skip, take, includePrerelease, includeExplanation, query);
            }
            finally
            {
                searcherManager.Release(searcher);
            }
        }

        public static void AutoComplete(JsonWriter jsonWriter, NuGetSearcherManager searcherManager, string q, string id, bool includePrerelease, int skip, int take, bool includeExplanation)
        {
            var searcher = searcherManager.Get();
            try
            {
                Filter filter = searcher.GetFilter(false, includePrerelease, null);

                if (q != null)
                {
                    Query query = MakeAutoCompleteQuery(q, searcher.Rankings);
                    TopDocs topDocs = searcher.Search(query, filter, skip + take);
                    ResponseFormatter.WriteAutoCompleteResult(jsonWriter, searcher, topDocs, skip, take, includeExplanation, query);
                }
                else
                {
                    Query query = MakeAutoCompleteVersionQuery(id);
                    TopDocs topDocs = searcher.Search(query, filter, 1);
                    ResponseFormatter.WriteAutoCompleteVersionResult(jsonWriter, searcher, includePrerelease, topDocs);
                }
            }
            finally
            {
                searcherManager.Release(searcher);
            }
        }

        public static void Find(JsonWriter jsonWriter, NuGetSearcherManager searcherManager, string id, string scheme)
        {
            var searcher = searcherManager.Get();
            try
            {
                Query query = MakeFindQuery(id);
                TopDocs topDocs = searcher.Search(query, 1);
                ResponseFormatter.WriteFindResult(jsonWriter, searcher, scheme, topDocs);
            }
            finally
            {
                searcherManager.Release(searcher);
            }
        }

        private static Query MakeSearchQuery(string q, IDictionary<string, int> rankings)
        {
            try
            {
                Query query = NuGetQuery.MakeQuery(q);
                Query boostedQuery = new RankingScoreQuery(query, rankings);
                return boostedQuery;
            }
            catch (ParseException)
            {
                throw new ClientException(HttpStatusCode.BadRequest, "Invalid query format");
            }
        }

        private static Query MakeAutoCompleteQuery(string q, IDictionary<string, int> rankings)
        {
            if (string.IsNullOrEmpty(q))
            {
                return new MatchAllDocsQuery();
            }

            QueryParser queryParser = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, "IdAutocomplete", new PackageAnalyzer());
            Query query = queryParser.Parse(q);
            Query boostedQuery = new RankingScoreQuery(query, rankings, 2.0);

            return boostedQuery;
        }

        private static Query MakeAutoCompleteVersionQuery(string id)
        {
            Query query = new TermQuery(new Term("Id", id.ToLowerInvariant()));
            return query;
        }

        private static Query MakeFindQuery(string id)
        {
            string analyzedId = id.ToLowerInvariant();
            Query query = new TermQuery(new Term("Id", analyzedId));
            return query;
        }
    }
}