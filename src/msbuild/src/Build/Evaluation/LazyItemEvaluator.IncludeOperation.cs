﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Build.Construction;
using System.Collections.Immutable;
using Microsoft.Build.Internal;
using Microsoft.Build.Shared;

namespace Microsoft.Build.Evaluation
{
    internal partial class LazyItemEvaluator<P, I, M, D>
    {
        class IncludeOperation : LazyItemOperation
        {
            readonly int _elementOrder;
            
            readonly string _rootDirectory;

            readonly ImmutableList<string> _excludes;

            readonly ImmutableList<ProjectMetadataElement> _metadata;

            public IncludeOperation(IncludeOperationBuilder builder, LazyItemEvaluator<P, I, M, D> lazyEvaluator)
                : base(builder, lazyEvaluator)
            {
                _elementOrder = builder.ElementOrder;
                _rootDirectory = builder.RootDirectory;

                _excludes = builder.Excludes.ToImmutable();
                _metadata = builder.Metadata.ToImmutable();
            }

            protected override ICollection<I> SelectItems(ImmutableList<ItemData>.Builder listBuilder, ImmutableHashSet<string> globsToIgnore)
            {
                List<I> itemsToAdd = new List<I>();

                Lazy<Func<string, bool>> excludeTester = null;
                ImmutableList<string>.Builder excludePatterns = ImmutableList.CreateBuilder<string>();
                if (_excludes != null)
                {
                    // STEP 4: Evaluate, split, expand and subtract any Exclude
                    foreach (string exclude in _excludes)
                    {
                        string excludeExpanded = _expander.ExpandIntoStringLeaveEscaped(exclude, ExpanderOptions.ExpandPropertiesAndItems, _itemElement.ExcludeLocation);
                        IList<string> excludeSplits = ExpressionShredder.SplitSemiColonSeparatedList(excludeExpanded);
                        excludePatterns.AddRange(excludeSplits);
                    }

                    if (excludePatterns.Any())
                    {
                        excludeTester = new Lazy<Func<string, bool>>(() => EngineFileUtilities.GetFileSpecMatchTester(excludePatterns, _rootDirectory));
                    }
                }

                ISet<string> excludePatternsForGlobs = null;

                foreach (var fragment in _itemSpec.Fragments)
                {
                    if (fragment is ItemExpressionFragment<P, I>)
                    {
                        // STEP 3: If expression is "@(x)" copy specified list with its metadata, otherwise just treat as string
                        bool throwaway;
                        var itemsFromExpression = _expander.ExpandExpressionCaptureIntoItems(
                            ((ItemExpressionFragment<P, I>)fragment).Capture, _evaluatorData, _itemFactory, ExpanderOptions.ExpandItems,
                            false /* do not include null expansion results */, out throwaway, _itemElement.IncludeLocation);

                        if (excludeTester != null)
                        {
                            itemsToAdd.AddRange(itemsFromExpression.Where(item => !excludeTester.Value(item.EvaluatedInclude)));
                        }
                        else
                        {
                            itemsToAdd.AddRange(itemsFromExpression);
                        }
                    }
                    else if (fragment is ValueFragment)
                    {
                        string value = ((ValueFragment)fragment).ItemSpecFragment;

                        if (excludeTester == null ||
                            !excludeTester.Value(EscapingUtilities.UnescapeAll(value)))
                        {
                            var item = _itemFactory.CreateItem(value, value, _itemElement.ContainingProject.FullPath);
                            itemsToAdd.Add(item);
                        }
                    }
                    else if (fragment is GlobFragment)
                    {
                        string glob = ((GlobFragment)fragment).ItemSpecFragment;

                        if (excludePatternsForGlobs == null)
                        {
                            excludePatternsForGlobs = BuildExcludePatternsForGlobs(globsToIgnore, excludePatterns);
                        }

                        string[] includeSplitFilesEscaped = EngineFileUtilities.GetFileListEscaped(
                            _rootDirectory,
                            glob,
                            excludePatternsForGlobs
                            );

                        // itemsToAdd might grow 0 or more times during the following iteration. Proactively increase its capacity to ensure only one growth happens
                        IncreaseListCapacityIfNecessary(itemsToAdd, includeSplitFilesEscaped.Length);

                        foreach (string includeSplitFileEscaped in includeSplitFilesEscaped)
                        {
                            itemsToAdd.Add(_itemFactory.CreateItem(includeSplitFileEscaped, glob, _itemElement.ContainingProject.FullPath));
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException(fragment.GetType().ToString());
                    }
                }

                return itemsToAdd;
            }

            private static ISet<string> BuildExcludePatternsForGlobs(ImmutableHashSet<string> globsToIgnore, ImmutableList<string>.Builder excludePatterns)
            {
                var anyExcludes = excludePatterns.Count > 0;
                var anyGlobstoIgnore = globsToIgnore.Count > 0;

                if (anyGlobstoIgnore && anyExcludes)
                {
                    return excludePatterns.Concat(globsToIgnore).ToImmutableHashSet();
                }

                return anyExcludes ? excludePatterns.ToImmutableHashSet() : globsToIgnore;
            }

            private void IncreaseListCapacityIfNecessary(List<I> list, int itemsToAdd)
            {
                var newLength = list.Count + itemsToAdd;

                if (list.Capacity < newLength)
                {
                    list.Capacity = newLength;
                }
            }

            protected override void MutateItems(ICollection<I> items)
            {
                DecorateItemsWithMetadata(items, _metadata);
            }

            protected override void SaveItems(ICollection<I> items, ImmutableList<ItemData>.Builder listBuilder)
            {
                foreach (var item in items)
                {
                    listBuilder.Add(new ItemData(item, _itemElement, _elementOrder, _conditionResult));
                }
            }
        }

        class IncludeOperationBuilder : OperationBuilderWithMetadata
        {
            public int ElementOrder { get; set; }
            public string RootDirectory { get; set; }

            public ImmutableList<string>.Builder Excludes { get; set; } = ImmutableList.CreateBuilder<string>();

            public IncludeOperationBuilder(ProjectItemElement itemElement, bool conditionResult) : base(itemElement, conditionResult)
            {
            }
        }
    }
}
