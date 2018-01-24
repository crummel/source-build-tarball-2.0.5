﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Newtonsoft.Json;

namespace NuGet.Indexing
{
    public interface ILoader
    {
        JsonReader GetReader(string name);
    }
}
