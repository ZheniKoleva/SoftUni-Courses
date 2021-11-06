function pipesInPool(input) {
    let poolVolume = parseInt(input[0]);
    let debitP1 = parseInt(input[1]);
    let debitP2 = parseInt(input[2]);
    let hours = Number(input[3]);

    let volumePipe1 = debitP1 * hours;
    let volumePipe2 = debitP2 * hours;
    let volumePipes = volumePipe1 + volumePipe2;

    let percentFilled = (volumePipes / poolVolume) * 100;
    let percentPipe1 = (volumePipe1 / volumePipes) * 100;
    let percentPipe2 = (volumePipe2 / volumePipes) * 100;

    if (poolVolume >= volumePipes) {
        console.log(`The pool is ${percentFilled.toFixed(2)}% full. Pipe 1: ${percentPipe1.toFixed(2)}%. Pipe 2: ${percentPipe2.toFixed(2)}%`);
    } else {
        let difference = volumePipes - poolVolume;
        console.log(`For ${hours.toFixed(2)} hours the pool overflows with ${difference.toFixed(2)} liters.`);
    }
}
pipesInPool(["1000", "100", "120", "3"]);
pipesInPool(["100", "100", "100", "2.5"]);