function dishwasher(input) {
    let index = 0;
    let bottlesCount = parseInt(input[index++]);

    const bottleAmount = 750;
    const amountPerDish = 5;
    const amountPerPot = 15;

    let totalAmount = bottlesCount * bottleAmount;
    let loadCount = 0;
    let dishesCount = 0;
    let potsCount = 0;
    let isFinished = false;

    let command = input[index];
    while (command !== "End") {
        let currentCount = parseInt(input[index++]);
        loadCount++;

        if (loadCount % 3 == 0) {
            potsCount += currentCount;
            totalAmount -= currentCount * amountPerPot;

        } else {
            dishesCount += currentCount;
            totalAmount -= currentCount * amountPerDish;
        }

        if (totalAmount < 0) {
            isFinished = true;
            break;
        }
        command = input[index];
    }

    if (isFinished) {
        console.log(`Not enough detergent, ${Math.abs(totalAmount)} ml. more necessary!`);
    } else {
        console.log("Detergent was enough!\n"
            + `${dishesCount} dishes and ${potsCount} pots were washed.\n`
            + `Leftover detergent ${totalAmount} ml.`);
    }
}
dishwasher(["2", "53", "65", "55", "End"]);
console.log(`----------------`);
dishwasher(["1", "10", "15", "10", "12", "13", "30"]);