# Build with NET6.0 SDK
# Platform: osx-x64

try {
    Push-Location
    cd ../../GameController/
    dotnet publish GameController.csproj --no-self-contained --framework net6.0 --runtime osx-x64 --output bin/Release/net6.0/publish/osx-x64
}
finally {
    Pop-Location
}