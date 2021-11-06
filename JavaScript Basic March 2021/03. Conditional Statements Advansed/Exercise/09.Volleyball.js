function volleyball(input) {
    let year = input[0];
    let holidaysCount = parseInt(input[1]);
    let weekendsTravel = parseInt(input[2]);

    let weekendsInSofia = 48 - weekendsTravel;
    let playCount = (weekendsInSofia * 3 / 4) + (holidaysCount * 2 / 3) + weekendsTravel;
    if (year === "leap") {
        playCount += playCount * 0.15;
    }
    console.log(Math.floor(playCount));
}
volleyball(["leap", "5", "2"]);

volleyball(["normal", "3", "2"]);

volleyball(["leap", "2", "3"]);

volleyball(["normal", "11", "6"]);

volleyball(["leap", "0", "1"]);

volleyball(["normal", "6", "13"]);



