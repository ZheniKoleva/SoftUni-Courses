function fishingBoat(input) {
    let budget = Number(input[0]);
    let season = input[1].toLowerCase();
    let fishermenCount = parseInt(input[2]);

    let rent;
    switch (season) {
        case "spring":
            rent = 3000; break;
        case "summer":
        case "autumn":
            rent = 4200; break;
        case "winter":
            rent = 2600; break;
    }
    if (fishermenCount <= 6) {
        rent -= rent * 0.10;

    }else if (fishermenCount <= 11) {
        rent -= rent * 0.15;

    }else {
        rent -= rent * 0.25;
    }

    if (fishermenCount % 2 == 0 && season !== "autumn") {
        rent -= rent * 0.05;
    }
    let difference = Math.abs(budget - rent).toFixed(2);

    if (budget >= rent) {
        console.log(`Yes! You have ${difference} leva left.`);
    }else {
        console.log(`Not enough money! You need ${difference} leva.`);
    }
}
fishingBoat(["3000",
    "Summer",
    "11"]);

fishingBoat(["3600",
    "Autumn",
    "6"]);

fishingBoat(["2000",
    "Winter",
    "13"]);


