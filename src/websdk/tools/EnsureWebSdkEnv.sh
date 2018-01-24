SCRIPT_ROOT="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"

if [ -z "${WebSdkRoot:-}" ]; then
    echo Initializing web sdk environment
    . "$SCRIPT_ROOT/WebSdkEnv.sh"
fi
