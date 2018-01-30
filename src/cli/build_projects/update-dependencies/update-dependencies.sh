#!/usr/bin/env bash
#
# Copyright (c) .NET Foundation and contributors. All rights reserved.
# Licensed under the MIT license. See LICENSE file in the project root for full license information.
#

set -e

SOURCE="${BASH_SOURCE[0]}"
while [ -h "$SOURCE" ]; do # resolve $SOURCE until the file is no longer a symlink
  DIR="$( cd -P "$( dirname "$SOURCE" )" && pwd )"
  SOURCE="$(readlink "$SOURCE")"
  [[ "$SOURCE" != /* ]] && SOURCE="$DIR/$SOURCE" # if $SOURCE was a relative symlink, we need to resolve it relative to the path where the symlink file was located
done
DIR="$( cd -P "$( dirname "$SOURCE" )" && pwd )"

REPO_ROOT="$DIR/../.."
PROJECT_PATH="$DIR/update-dependencies.csproj"

# Some things depend on HOME and it may not be set. We should fix those things, but until then, we just patch a value in
if [ -z "${HOME:-}" ]; then
    export HOME=$REPO_ROOT/artifacts/home

    [ ! -d "$HOME" ] || rm -Rf "$HOME"
    mkdir -p "$HOME"
fi

# Use a repo-local install directory (but not the artifacts directory because that gets cleaned a lot)
if [ -z "${DOTNET_INSTALL_DIR:-}" ]; then
   export DOTNET_INSTALL_DIR=$REPO_ROOT/.dotnet_stage0/x64
fi

if [ ! -d "$DOTNET_INSTALL_DIR" ]; then
    mkdir -p $DOTNET_INSTALL_DIR
fi

cp -r $DOTNET_TOOL_DIR/* $DOTNET_INSTALL_DIR/

ln -s $DOTNET_INSTALL_DIR/shared/Microsoft.NETCore.App/2.0.0-preview1-002111-00 $DOTNET_INSTALL_DIR/shared/Microsoft.NETCore.App/2.0.0-preview2-002066-00

# Put the stage 0 on the path
export PATH=$DOTNET_INSTALL_DIR:$PATH

echo "Restoring $PROJECT_PATH..."
dotnet restore "$PROJECT_PATH"

if [ $? -ne 0 ]; then
    echo "Failed to restore"
    exit 1
fi

echo "Invoking App $PROJECT_PATH..."
dotnet run -p "$PROJECT_PATH" $@

if [ $? -ne 0 ]; then
    echo "Build failed"
    exit 1
fi
