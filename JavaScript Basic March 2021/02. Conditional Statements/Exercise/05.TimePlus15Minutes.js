function timePlus15Min(input) {
    let hour = parseInt(input[0]);
    let min = parseInt(input[1]);

    min += 15;
    if (min >= 60) {
        min -= 60;
        hour++;
    }

    if (hour > 23) {
        hour =0;
    }

    if (min < 10) {
        console.log(`${hour}:0${min}`);
    } else {
        console.log(`${hour}:${min}`);
    }
}
timePlus15Min(["1", "46"]);
timePlus15Min(["0", "01"]);
timePlus15Min(["23", "59"]);
timePlus15Min(["11", "08"]);
timePlus15Min(["12", "49"]);