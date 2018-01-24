// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;
using System;
using System.Threading;

namespace NuGet.Indexing
{
    public abstract class SearcherManager<TIndexSearcher>
        where TIndexSearcher : IndexSearcher
    {
        private readonly object _sync = new object();
        private bool _reopening;
        private TIndexSearcher _currentSearcher;

        public Directory Directory { get; private set; }

        public SearcherManager(Directory directory)
        {
            Directory = directory;
        }

        public void Open()
        {
            if (_currentSearcher == null)
            {
                lock (_sync)
                {
                    if (_currentSearcher == null)
                    {
                        _currentSearcher = CreateSearcher(IndexReader.Open(Directory, true));
                        if (_currentSearcher == null)
                        {
                            throw new Exception("Unable to create IndexSearcher");
                        }
                    }
                }
            }
            Warm(_currentSearcher);
        }

        protected abstract IndexReader Reopen(IndexSearcher searcher);

        protected abstract TIndexSearcher CreateSearcher(IndexReader reader);

        protected virtual void Warm(TIndexSearcher searcher)
        {
        }

        private void StartReopen()
        {
            lock (_sync)
            {
                while (_reopening)
                {
                    Monitor.Wait(_sync);
                }
                _reopening = true;
            }
        }

        private void DoneReopen()
        {
            lock (_sync)
            {
                _reopening = false;
                Monitor.PulseAll(_sync);
            }
        }
        public void MaybeReopen()
        {
            StartReopen();

            try
            {
                TIndexSearcher searcher = Get();
                try
                {
                    //var newReader = _currentSearcher.IndexReader.Reopen();
                    var newReader = Reopen(_currentSearcher);

                    if (newReader != _currentSearcher.IndexReader)
                    {
                        var newSearcher = CreateSearcher(newReader);
                        if (newSearcher != null)
                        {
                            Warm(newSearcher);
                            SwapSearcher(newSearcher);
                        }
                    }
                }
                finally
                {
                    Release(searcher);
                }
            }
            finally
            {
                DoneReopen();
            }
        }

        public TIndexSearcher Get()
        {
            lock (_sync)
            {
                _currentSearcher.IndexReader.IncRef();
                return _currentSearcher;
            }
        }

        public void Release(TIndexSearcher searcher)
        {
            lock (_sync)
            {
                searcher.IndexReader.DecRef();
            }
        }

        private void SwapSearcher(TIndexSearcher newSearcher)
        {
            lock (_sync)
            {
                Release(_currentSearcher);
                _currentSearcher = newSearcher;
            }
        }

        public void Close()
        {
            SwapSearcher(null);
        }
    }
}