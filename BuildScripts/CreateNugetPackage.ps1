# Creates a NuGet package from the ArgData project and copies the created .nupkg file to the Build\Artifacts folder
#
# Uses the version number (and other properties) from ArgData.csproj

dotnet test "$PSScriptRoot\..\Source\ArgData.Tests\"

dotnet pack "$PSScriptRoot\..\Source\ArgData\ArgData.csproj" -c Release

Copy-Item -Path "$PSScriptRoot\..\Source\ArgData\bin\Release\*.nupkg" -Destination "$PSScriptRoot\Artifacts"
