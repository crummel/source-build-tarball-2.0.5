#!/bin/bash

set -euo pipefail
IFS=$'\n\t'

SCRIPT_ROOT="$(dirname "${BASH_SOURCE[0]}")"
DOTNET_TOOL_ROOT="$SCRIPT_ROOT/obj/tools/dotnet"

mkdir -p $DOTNET_TOOL_ROOT
cp -r $DOTNET_TOOL_DIR/* $DOTNET_TOOL_ROOT

export PATH=$DOTNET_TOOL_ROOT:$PATH

$SCRIPT_ROOT/tools/BuildCore.sh
