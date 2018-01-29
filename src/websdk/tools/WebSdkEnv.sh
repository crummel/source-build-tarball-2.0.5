#!/bin/bash

SCRIPT_ROOT="$(cd "$(dirname "${BASH_SOURCE[0]}" )" && pwd)"

export WebSdkRoot="$(dirname $SCRIPT_ROOT)/"
export WebSdkBin="${WebSdkRoot}bin/"
export WebSdkIntermediate="${WebSdkRoot}obj/"
export WebSdkReferences="${WebSdkRoot}references/"
export WebSdkSource="${WebSdkRoot}src/"
export WebSdkTools="${WebSdkRoot}tools/"

export PATH="$WebSdkTools:$PATH"
