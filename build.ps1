param(
    [string]$NotchCorePath = "$env:LOCALAPPDATA\Programs\Notch\Notch.Core.dll"
)

$ErrorActionPreference = 'Stop'
$pluginOutput = Join-Path $PSScriptRoot 'dist\brick-bread.catppuccin'
$projectFile = Join-Path $PSScriptRoot 'Notch.Catppuccin.csproj'
$manifest = Get-Content -LiteralPath (Join-Path $PSScriptRoot 'plugin.json') -Raw | ConvertFrom-Json
$pluginVersion = [version]::Parse($manifest.version).ToString()
$archivePath = Join-Path $PSScriptRoot "dist\notch-catppuccin-$pluginVersion.zip"

dotnet publish $projectFile -c Release -o $pluginOutput "-p:NotchCorePath=$NotchCorePath" "-p:Version=$pluginVersion" --nologo
if ($LASTEXITCODE -ne 0) { throw 'The plugin build failed.' }
if (Test-Path -LiteralPath (Join-Path $pluginOutput 'Notch.Core.dll')) {
    throw 'Notch.Core.dll must not be shipped with a plugin.'
}
Compress-Archive -Path (Join-Path $pluginOutput '*') -DestinationPath $archivePath -Force
Write-Output "Plugin folder: $pluginOutput"
Write-Output "Release archive: $archivePath"
