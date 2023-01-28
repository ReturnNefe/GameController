# Build with NET6.0 SDK
# Platform: Win-arm64

try {
    Push-Location
    cd ../../GameController/
    dotnet publish GameController.csproj --no-self-contained --framework net6.0 --runtime win-arm64 --output bin/Release/net6.0/publish/win-arm64
}
finally {
    Pop-Location
}