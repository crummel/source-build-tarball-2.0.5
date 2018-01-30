﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Microsoft.Build.Evaluation
{
    internal partial class LazyItemEvaluator<P, I, M, D>
    {
        class RemoveOperation : LazyItemOperation
        {
            public RemoveOperation(OperationBuilder builder, LazyItemEvaluator<P, I, M, D> lazyEvaluator)
                : base(builder, lazyEvaluator)
            {
            }

            // todo port the self referencing matching optimization (e.g. <I Remove="@(I)">) from Update to Remove as well. Ideally make one mechanism for both. https://github.com/Microsoft/msbuild/issues/2314
            // todo Perf: do not match against the globs: https://github.com/Microsoft/msbuild/issues/2329
            protected override ImmutableList<I> SelectItems(ImmutableList<ItemData>.Builder listBuilder, ImmutableHashSet<string> globsToIgnore)
            {
                var items = ImmutableHashSet.CreateBuilder<I>();
                foreach (ItemData item in listBuilder)
                {
                    if (_itemSpec.MatchesItem(item.Item))
                        items.Add(item.Item);
                }

                return items.ToImmutableList();
            }

            protected override void SaveItems(ImmutableList<I> items, ImmutableList<ItemData>.Builder listBuilder)
            {
                if (!_conditionResult)
                {
                    return;
                }

                // bug in ImmutableList<T>.Builder.RemoveAll. In some cases it will remove elements for which the RemoveAll predicate is false
                // MSBuild issue: https://github.com/Microsoft/msbuild/issues/2069
                // corefx issue: https://github.com/dotnet/corefx/issues/20609
                //listBuilder.RemoveAll(itemData => items.Contains(itemData.Item));

                // Replacing RemoveAll with Remove fixes the above issue 

                // DeLINQified for perf
                //var itemDataToRemove = listBuilder.Where(itemData => items.Contains(itemData.Item)).ToList();
                var itemDataToRemove = new List<ItemData>();
                foreach (var itemData in listBuilder)
                {
                    if (items.Contains(itemData.Item))
                    {
                        itemDataToRemove.Add(itemData);
                    }
                }

                foreach (var itemToRemove in itemDataToRemove)
                {
                    listBuilder.Remove(itemToRemove);
                }
            }

            public ImmutableHashSet<string>.Builder GetRemovedGlobs()
            {
                var builder = ImmutableHashSet.CreateBuilder<string>();

                if (!_conditionResult)
                {
                    return builder;
                }

                var globs = _itemSpec.Fragments.OfType<GlobFragment>().Select(g => g.ItemSpecFragment);

                builder.UnionWith(globs);

                return builder;
            }
        }
    }
}
