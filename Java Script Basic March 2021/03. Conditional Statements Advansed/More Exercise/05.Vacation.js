function vacation(input) {
    let budget = Number(input[0]);
    let season = input[1].toLowerCase();

    let destination = season === "summer" ? "Alaska" : "Morocco";
    let accommodation = null;
    let vacationPrice = null;

    if (budget <= 1000) {
        accommodation = "Camp";
        vacationPrice = season === "summer" ? budget * 0.65 : budget * 0.45;

    }else if (budget <= 3000) {
        accommodation = "Hut";
        vacationPrice = season === "summer" ? budget * 0.80 : budget * 0.60;

    }else {
        accommodation = "Hotel";
        vacationPrice = budget * 0.90;
    }
    console.log(`${destination} - ${accommodation} - ${vacationPrice.toFixed(2)}`);
}
vacation(["800", "Summer"]);

vacation(["799.50", "Winter"]);

vacation(["3460", "Summer"]);

vacation(["1100", "Summer"]);

vacation(["5000", "Winter"]);

vacation(["2543.99", "Winter"]);