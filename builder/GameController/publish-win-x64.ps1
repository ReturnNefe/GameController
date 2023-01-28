# Build with NET6.0 SDK
# Platform: Win-x64

Push-Location
cd ../../GameController/
dotnet publish GameController.csproj --no-self-contained --framework net6.0 --runtime win-x64 --output bin/Release/net6.0/publish/win-x64
Pop-Location