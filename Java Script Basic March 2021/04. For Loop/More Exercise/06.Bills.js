function bills(input) {
    let monthsCount = parseInt(input[0]);

    let waterTax = 20;
    let internetTax = 15;
    let electricitySum = 0.00;
    let others = 0.00;
    let othersTotal = 0.00;
    let totalSum = 0.00;

    for (let index = 1; index <= monthsCount; index++) {
        let electricity = Number(input[index]);
        electricitySum += electricity;
        others = (waterTax + internetTax + electricity) * 1.20;
        othersTotal += others;
        totalSum += waterTax + internetTax + electricity + others;
    }    

    console.log(`Electricity: ${electricitySum.toFixed(2)} lv\n`
        + `Water: ${(waterTax * monthsCount).toFixed(2)} lv\n`
        + `Internet: ${(internetTax * monthsCount).toFixed(2)} lv\n`
        + `Other: ${othersTotal.toFixed(2)} lv\n`
        + `Average: ${(totalSum / monthsCount).toFixed(2)} lv`);
}
bills(["5", "68.63", "89.25", "132.53", "93.53", "63.22"]);
bills(["8", "123.54", "231.54", "140.23", "100", "122.4", "430", "178.52", "64.2 "]);