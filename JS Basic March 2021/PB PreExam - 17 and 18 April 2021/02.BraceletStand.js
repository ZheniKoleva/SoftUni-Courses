function braceletStand(input) {
    let moneyPerDay = Number(input[0]);
    let moneyEarnedPerDay = Number(input[1]);
    let expences = Number(input[2]);
    let presentPrice = Number(input[3]);
        
    const days = 5;

    let profit = (moneyPerDay + moneyEarnedPerDay) * days;
    profit -= expences;

    if (profit >= presentPrice) {
        console.log(`Profit: ${profit.toFixed(2)} BGN, the gift has been purchased.`);

    } else {
        let difference = presentPrice - profit;
        console.log(`Insufficient money: ${difference.toFixed(2)} BGN.`)
    }
}
braceletStand(["5.12",
"32.05",
"15",
"150"]);

braceletStand(["2.10",
"17.50",
"20.20",
"148.50"]);

braceletStand(["15.20",
"200.00",
"7.30",
"1500.12"]);


