function cleverLily(input) {
    let age = parseInt(input[0]);
    let laundryPrice = Number(input[1]);
    let pricePerToy = Number(input[2]);

    let moneySaved = 0.00;
    let moneyGiven = 10.00;
    let toyCount = 0;

    for (let currentYear = 1; currentYear <= age; currentYear++) {
       if (currentYear % 2 == 0) {
           moneySaved += moneyGiven;
           moneyGiven += 10.00;
           moneySaved--;

       } else {
           toyCount++;
       }

    }

    moneySaved += (toyCount * pricePerToy);
    let difference = Math.abs(moneySaved - laundryPrice);

    if (moneySaved >= laundryPrice) {
        console.log(`Yes! ${difference.toFixed(2)}`);

    } else {
        console.log(`No! ${difference.toFixed(2)}`);
    }

}
cleverLily(["10", "170", "6"]);
cleverLily(["21", "1570.98", "3"]);