
Usage: fsi.exe <options> [script.fsx [<arguments>]]


		- INPUT FILES -
--use:<file>                   Use the given file on startup as initial input
--load:<file>                  #load the given file on startup
--reference:<file>             Reference an assembly (Short form: -r)
-- ...                         Treat remaining arguments as command line
                               arguments, accessed using fsi.CommandLineArgs


		- CODE GENERATION -
--debug[+|-]                   Emit debug information (Short form: -g)
--debug:{full|pdbonly|portable} Specify debugging type: full, portable, pdbonly.
                               ('pdbonly' is the default if no debuggging type
                               specified and enables attaching a debugger to a
                               running program. 'portable' is a cross-platform
                               format).
--optimize[+|-]                Enable optimizations (Short form: -O)
--tailcalls[+|-]               Enable or disable tailcalls
--deterministic[+|-]           Produce a deterministic assembly (including
                               module version GUID and timestamp)
--crossoptimize[+|-]           Enable or disable cross-module optimizations


		- ERRORS AND WARNINGS -
--warnaserror[+|-]             Report all warnings as errors
--warnaserror[+|-]:<warn;...>  Report specific warnings as errors
--warn:<n>                     Set a warning level (0-4)
--nowarn:<warn;...>            Disable specific warning messages


		- LANGUAGE -
--checked[+|-]                 Generate overflow checks
--define:<string>              Define conditional compilation symbols (Short
                               form: -d)
--mlcompatibility              Ignore ML compatibility warnings


		- MISCELLANEOUS -
--nologo                       Suppress compiler copyright message
--help                         Display this usage message (Short form: -?)


		- ADVANCED -
--codepage:<n>                 Specify the codepage used to read source files
--utf8output                   Output messages in UTF-8 encoding
--fullpaths                    Output messages with fully qualified paths
--lib:<dir;...>                Specify a directory for the include path which
                               is used to resolve source files and assemblies
                               (Short form: -I)
--simpleresolution             Resolve assembly references using
                               directory-based rules rather than MSBuild
                               resolution
--targetprofile:<string>       Specify target framework profile of this
                               assembly. Valid values are mscorlib or netcore.
                               Default - mscorlib
--noframework                  Do not reference the default CLI assemblies by
                               default
--exec                         Exit fsi after loading the files or running the
                               .fsx script given on the command line
--gui[+|-]                     Execute interactions on a Windows Forms event
                               loop (on by default)
--quiet                        Suppress fsi writing to stdout
--readline[+|-]                Support TAB completion in console (on by
                               default)
