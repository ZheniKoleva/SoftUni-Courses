function competetion(input) {
    let dancersCount = parseInt(input.shift());
    let points = Number(input.shift());
    let season = input.shift();
    let location = input.shift();

    let sumEarned = points * dancersCount;
    let expenses = 0;

    switch (location) {
        case "Bulgaria":
            if (season === "summer") {
                expenses = 0.05;

            } else if (season === "winter") {
                expenses = 0.08;
            }
            break;

        case "Abroad":
            sumEarned *= 1.50;
            if (season === "summer") {
                expenses = 0.10;

            } else if (season === "winter") {
                expenses = 0.15;
            }
            break;
    }

    sumEarned -= sumEarned * expenses;
    let charitySum = sumEarned * 0.75;
    sumEarned -= charitySum;
    let moneyPerDancer = sumEarned / dancersCount;

    console.log(`Charity - ${charitySum.toFixed(2)}\n`
        + `Money per dancer - ${moneyPerDancer.toFixed(2)}`);

}
competetion(["1",
"89.5",
"summer",
"Abroad"]);

competetion(["25",
"98",
"winter",
"Bulgaria"]);

