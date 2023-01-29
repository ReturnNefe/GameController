# Build with NET6.0 SDK
# Platform: Linux-x64

try {
    Push-Location
    cd ../../GameController/
    dotnet publish GameController.csproj --no-self-contained --framework net6.0 --runtime linux-x64 --output bin/Release/net6.0/publish/linux-x64
}
finally {
    Pop-Location
}