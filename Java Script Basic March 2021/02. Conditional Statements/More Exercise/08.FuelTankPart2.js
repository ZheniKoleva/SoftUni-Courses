function fuelTankPart2(input) {
    let typeOfFuel = input[0].toLowerCase();
    let fuelQuantity = Number(input[1]);
    let hasClubCard = input[2].toLowerCase();

    let gasolinePrice = 2.22;
    let dieselPrice = 2.33;
    let gasPrice = 0.93; 
    let totalSum = 0.00;   

    switch (hasClubCard) {
        case "yes":
            gasolinePrice -= 0.18;
            dieselPrice -= 0.12;
            gasPrice -= 0.08;
            break;
    }

    switch (typeOfFuel) {
        case "gasoline":
            totalSum = fuelQuantity * gasolinePrice;
            break;
        case "diesel":
            totalSum = fuelQuantity * dieselPrice;
            break;
        case "gas":
            totalSum = fuelQuantity * gasPrice;
            break;
    }

    if (fuelQuantity >= 20 && fuelQuantity <= 25) {
        totalSum -= totalSum * 0.08;
    } else if (fuelQuantity > 25) {
        totalSum -= totalSum * 0.10;
    }

    console.log(`${totalSum.toFixed(2)} lv.`)
}
fuelTankPart2(["Gas", "30", "Yes"]);
fuelTankPart2(["Gasoline", "25", "No"]);
fuelTankPart2(["Diesel", "19", "No"]);