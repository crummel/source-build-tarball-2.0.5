# Copyright (c) Microsoft. All rights reserved.
# Build script for Test Platform.

[CmdletBinding()]
Param(
    [Parameter(Mandatory=$false)]
    [ValidateSet("Debug", "Release")]
    [Alias("c")]
    [System.String] $Configuration = "Debug",

    [Parameter(Mandatory=$true)]
    [Alias("cert")]
    [System.String] $Certificate
)

$ErrorActionPreference = "Continue"

#
# Variables
#
Write-Verbose "Setup environment variables."
$env:TP_ROOT_DIR = (Get-Item (Split-Path $MyInvocation.MyCommand.Path)).Parent.FullName
$env:TP_OUT_DIR = Join-Path $env:TP_ROOT_DIR "artifacts"

#
# Signing configuration
#
# Authenticode signature details
Write-Verbose "Setup build configuration."
$TPB_SignCertificate = $Certificate
$TPB_Configuration = $Configuration
$TPB_AssembliesPattern = @("*test*.dll", "*qualitytools*.dll", "*test*.exe", "*datacollector*.dll", "*datacollector*.exe", "Microsoft.TestPlatform.Build.dll")

function Verify-Signature
{
    Write-Log "Verify-Signature: Start"
    $artifactsDirectory = Join-Path $env:TP_OUT_DIR $TPB_Configuration
    foreach ($pattern in $TPB_AssembliesPattern) {
        Write-Log "... Pattern: $pattern"
        Get-ChildItem -Recurse -Include $pattern $artifactsDirectory | Where-Object { (!$_.PSIsContainer) -and !($($_.FullName).Contains('VSIX\obj')) } | % {
            $signature = Get-AuthenticodeSignature -FilePath $_.FullName

            if ($signature.Status -eq "Valid") {
                if ($signature.SignerCertificate.Thumbprint -eq $TPB_SignCertificate) {
                    Write-Log "Valid: $($_.FullName)"
                }
                else {
                    # For legacy components, sign certificate is always "prod" signature. Skip such binaries.
                    if ($signature.SignerCertificate.Thumbprint -eq "98ED99A67886D020C564923B7DF25E9AC019DF26") {
                        Write-Log "Valid (Prod Signed): $($_.FullName)."
                    }
                    else {
                        Write-FailLog "Incorrect certificate. File: $($_.FullName). Certificate: $($signature.SignerCertificate.Thumbprint)."
                    }
                }
            }
            else {
                Write-FailLog "Not signed. File: $($_.FullName)."
            }
        }
    }

    Write-Log "Verify-Signature: Complete"
}

function Write-Log ([string] $message)
{
    $currentColor = $Host.UI.RawUI.ForegroundColor
    $Host.UI.RawUI.ForegroundColor = "Green"
    if ($message)
    {
        Write-Output "... $message"
    }
    $Host.UI.RawUI.ForegroundColor = $currentColor
}

function Write-FailLog ([string] $message)
{
    if ($message)
    {
        Write-Error "... $message"
    }
}

Verify-Signature
