@echo off

call %~dp0\EnsureWebSdkEnv.cmd

call dotnet restore %WebSdkRoot%src\Publish\Microsoft.NET.Sdk.Publish.Tasks\Microsoft.NET.Sdk.Publish.Tasks.csproj /p:Configuration=Release
if errorlevel 1 GOTO ERROR

call dotnet build %WebSdkRoot%src\Publish\Microsoft.NET.Sdk.Publish.Tasks\Microsoft.NET.Sdk.Publish.Tasks.csproj /p:Configuration=Release
if errorlevel 1 GOTO ERROR

call dotnet pack %WebSdkRoot%build.dotnet.proj /p:Configuration=Release
if errorlevel 1 GOTO ERROR

endlocal

exit /b 0

:ERROR
exit /b 1
