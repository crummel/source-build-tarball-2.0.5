#!/bin/bash
set -euo pipefail
IFS=$'\n\t'

SCRIPT_ROOT="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"

. "$SCRIPT_ROOT/EnsureWebSdkEnv.sh"

dotnet restore "$WebSdkRoot/src/Publish/Microsoft.NET.Sdk.Publish.Tasks/Microsoft.NET.Sdk.Publish.Tasks.csproj" /p:Configuration=Release

dotnet build "$WebSdkRoot/src/Publish/Microsoft.NET.Sdk.Publish.Tasks/Microsoft.NET.Sdk.Publish.Tasks.csproj" /p:Configuration=Release

dotnet pack "$WebSdkRoot/build.dotnet.proj" /p:Configuration=Release
