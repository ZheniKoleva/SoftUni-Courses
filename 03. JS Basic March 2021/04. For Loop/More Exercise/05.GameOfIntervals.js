function gameOfIntervals(input) {
    let turnsCount = parseInt(input[0]);

    let points = 0.00;
    let numsTo9 = 0;
    let numsTo19 = 0;
    let numsTo29 = 0;
    let numsTo39 = 0;
    let numsTo50 = 0;
    let invalidNums = 0;

    for (let index = 1; index <= turnsCount; index++) {
        let currentNumber = parseInt(input[index]);

        if (currentNumber < 0 || currentNumber > 50) {
            invalidNums++;
            points /= 2;

        } else if (currentNumber < 10) {
            numsTo9++;
            points += currentNumber * 0.20;

        } else if (currentNumber < 20) {
            numsTo19++;
            points += currentNumber * 0.30;

        } else if (currentNumber < 30) {
            numsTo29++;
            points += currentNumber * 0.40;

        } else if (currentNumber < 40) {
            numsTo39++;
            points += 50;

        } else if (currentNumber <= 50) {
            numsTo50++;
            points += 100;
        }
    }

    console.log(`${points.toFixed(2)}\n`
        + `From 0 to 9: ${(numsTo9 / turnsCount * 100).toFixed(2)}%\n`
        + `From 10 to 19: ${(numsTo19 / turnsCount * 100).toFixed(2)}%\n`
        + `From 20 to 29: ${(numsTo29 / turnsCount * 100).toFixed(2)}%\n`
        + `From 30 to 39: ${(numsTo39 / turnsCount * 100).toFixed(2)}%\n`
        + `From 40 to 50: ${(numsTo50 / turnsCount * 100).toFixed(2)}%\n`
        + `Invalid numbers: ${(invalidNums / turnsCount * 100).toFixed(2)}%`);
}
gameOfIntervals(["10", "43", "57", "-12", "23", "12", "0", "50", "40", "30", "20"]);