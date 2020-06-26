# AAUtils
Dot Net Utilities

# Create nuget package
dotnet pack --configuration Release

# Upload
dotnet nuget push "bin/Release/AAUtilities.<versin>.nupkg" --source "github"