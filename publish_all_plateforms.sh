#
# Cross Compilation for Linux/Win/OSX plateforms
#

dotnet publish --configuration Release -r linux-x64
zip bb_exporter_linux-x64.zip bb_exporter/bin/Release/net6.0/linux-x64/publish/*.*

dotnet publish --configuration Release -r linux-arm
zip bb_exporter_linux-arm.zip bb_exporter/bin/Release/net6.0/linux-arm/publish/*.*

dotnet publish --configuration Release -r linux-arm64
zip bb_exporter_linux-arm64.zip bb_exporter/bin/Release/net6.0/linux-arm64/publish/*.*

dotnet publish --configuration Release -r win-x64
zip bb_exporter_win-x64.zip bb_exporter/bin/Release/net6.0/win-x64/publish/*.*

dotnet publish --configuration Release -r win-x86
zip bb_exporter_win-x86.zip bb_exporter/bin/Release/net6.0/win-x86/publish/*.*

dotnet publish --configuration Release -r osx-x64
zip bb_exporter_osx-x64.zip bb_exporter/bin/Release/net6.0/osx-x64/publish/*.*