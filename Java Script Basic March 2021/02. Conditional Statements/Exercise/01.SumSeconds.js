function sumSeconds(input) {
    let firstTime = parseInt(input[0]);
    let secondTime = parseInt(input[1]);
    let thirdTime = parseInt(input[2]);

    let totalTime = firstTime + secondTime + thirdTime;
    let minutes = Math.floor(totalTime / 60);
    let seconds = totalTime % 60;

    if (seconds < 10) {
        console.log(`${minutes}:0${seconds}`);
    } else {
        console.log(`${minutes}:${seconds}`);
    }
}
sumSeconds(["35", "45", "44"]);
sumSeconds(["22", "7", "34"]);
sumSeconds(["50", "50", "49"]);
sumSeconds(["14", "12", "10"]);