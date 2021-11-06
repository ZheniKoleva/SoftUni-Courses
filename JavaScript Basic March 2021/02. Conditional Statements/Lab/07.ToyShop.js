function toyShop(input) {
    let priceOfTrip = Number(input[0]);
    let puzzlesCount = parseInt(input[1]);
    let dollsCount = parseInt(input[2]);
    let bearsCount = parseInt(input[3]);
    let minionsCount = parseInt(input[4]);
    let trucksCount = parseInt(input[5]);

    const puzzlePrice = 2.60;
    const dollPrice = 3.00;
    const bearPrice = 4.10;
    const minionPrice = 8.20;
    const truckPrice = 2.00;

    let toysCount = puzzlesCount + dollsCount + bearsCount + minionsCount + trucksCount;
    let profit = (puzzlesCount * puzzlePrice) + (dollsCount * dollPrice) + (bearsCount * bearPrice) +
    (minionsCount * minionPrice) + (trucksCount * truckPrice);

    if (toysCount >= 50) {
        profit -= profit * 0.25;
    }

    profit -= profit * 0.10;
    let difference = profit - priceOfTrip;

    if (profit >= priceOfTrip) {
        console.log(`Yes! ${difference.toFixed(2)} lv left.`);

    } else {
        console.log(`Not enough money! ${Math.abs(difference).toFixed(2)} lv needed.`);

    }    
}
toyShop(["40.8", "20", "25", "30", "50", "10"]);
toyShop(["320", "8", "2", "5", "5", "1"]);