#
# Cross Compilation for Linux/Win/OSX plateforms
#

dotnet publish --configuration Release -r linux-x64
dotnet publish --configuration Release -r linux-arm
dotnet publish --configuration Release -r linux-arm64
dotnet publish --configuration Release -r win-x64
dotnet publish --configuration Release -r win-x86
dotnet publish --configuration Release -r osx-x64
