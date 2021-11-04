function goldMine(input) {
    let index = 0;
    let locationsCount = parseInt(input[index++]);

    for (let location = 0; location < locationsCount; location++) {

        let expectedAvgYield = Number(input[index++]);
        let daysCount = parseInt(input[index++]);

        let yieldTotal = 0.00;

        for (let day = 1; day <= daysCount; day++) {
            yieldTotal += Number(input[index++]);

        }

        let actualAvgYield = yieldTotal / daysCount;

        if (actualAvgYield >= expectedAvgYield) {
            console.log(`Good job! Average gold per day: ${actualAvgYield.toFixed(2)}.`);

        } else {
            let difference = expectedAvgYield - actualAvgYield;
            console.log(`You need ${difference.toFixed(2)} gold.`);
        }

    }

}
goldMine(["2",
"10",
"3",
"10",
"10",
"11",
"20",
"2",
"20",
"10"]);

goldMine(["1",
"5",
"3",
"10",
"1",
"3"]);

