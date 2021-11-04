function computerFirm(input) {
    let index = 0;
    let pcModelsCount = parseInt(input[index++]);

    let raitingsSum = 0.0;
    let salesTotal = 0;

    for (let i = 0; i < pcModelsCount; i++) {
        let number = Number(input[index++]);

        let raitingScore = parseInt(number % 10);
        let sales = parseInt(number / 10);

        if (raitingScore === 2) {
            sales = 0;

        } else if (raitingScore === 3) {
            sales *= 0.50;

        } else if (raitingScore === 4) {
            sales *= 0.70;

        } else if (raitingScore === 5) {
            sales *= 0.85;

        } else if (raitingScore === 6) {
            sales *= 1;
        }

        salesTotal += sales;
        raitingsSum += raitingScore;
    }

    let avgRaiting = raitingsSum / pcModelsCount;
    console.log(`${salesTotal.toFixed(2)}`);
    console.log(`${avgRaiting.toFixed(2)}`);
}
computerFirm(["3",
"103",
"103",
"103"]);

computerFirm(["5",
"122",
"156",
"202",
"214",
"185"]);

computerFirm(["2",
"204",
"206"]);


