function truckDriver(input) {
    let season = input[0].toLowerCase();
    let kmPerMonth = Number(input[1]);

    let montsInSeason = 4;
    let pricePerKm = 0.00;

    if (kmPerMonth <= 5000) {
        switch (season) {
            case "spring":
            case "autumn":
                pricePerKm = 0.75;
                break;
            case "summer":
                pricePerKm = 0.90;
                break;
            case "winter":
                pricePerKm = 1.05;
                break;
        }

    }else if (kmPerMonth <= 10000) {
        switch (season) {
            case "spring":
            case "autumn":
                pricePerKm = 0.95;
                break;
            case "summer":
                pricePerKm = 1.10;
                break;
            case "winter":
                pricePerKm = 1.25;
                break;
        }
    }else if (kmPerMonth <= 20000) {
        pricePerKm = 1.45;
    }

    let totalPrice = pricePerKm * kmPerMonth * montsInSeason;
    totalPrice -= totalPrice * 0.10;
    console.log(totalPrice.toFixed(2));
}
truckDriver(["Summer", "3455"]);
truckDriver(["Winter", "4350"]);
truckDriver(["Spring", "1600"]);
truckDriver(["Winter", "5678"]);
truckDriver(["Autumn", "8600"]);
truckDriver(["Winter", "16042"]);
truckDriver(["Spring", "16942"]);