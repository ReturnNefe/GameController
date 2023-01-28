try {
    Push-Location
    cd ../GameController/bin/Release/net6.0/publish/win-x64/
    ./GameController --config config.txt --url http://*:10000 --no-auto-open
}
finally {
    Pop-Location
}