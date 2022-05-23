function speedInfo(input) {
    let speed = Number(input[0]);
    let output = "";

    if (speed <= 10) {
        output = "slow";
    } else if (speed <= 50) {
        output = "average";
    } else if (speed <= 150) {
        output = "fast";
    } else if (speed <= 1000) {
        output = "ultra fast";
    }else {
        output = "extremely fast";
    }

    console.log(output);    
}
speedInfo(["8"]);
speedInfo(["49.5"]);
speedInfo(["126"]);
speedInfo(["160"]);
speedInfo(["3500"]);