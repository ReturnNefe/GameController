try {
    Push-Location
    cd ../GameController/bin/Release/net6.0/publish/win-x64/
    ./GameController --config ../../../../../../test/config-ets.txt --url http://*:10000 --no-auto-open
}
finally {
    Pop-Location
}