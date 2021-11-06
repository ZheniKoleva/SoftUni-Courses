function fuelTank(input) {
    let typeOfFuel = input[0].toLowerCase();
    let fuelQuantity = Number(input[1]);

    switch (typeOfFuel) {
        case "diesel":
        case "gasoline":
        case "gas":
            if (fuelQuantity >= 25) {
                console.log(`You have enough ${typeOfFuel}.`);

            } else {
                console.log(`Fill your tank with ${typeOfFuel}!`);
            }
            break;
    
        default:
            console.log("Invalid fuel!")
            break;
    }
}
fuelTank(["Diesel", "10"]);
fuelTank(["Gasoline", "40"]);
fuelTank(["Gas", "25"]);
fuelTank(["Kerosene", "200"]);