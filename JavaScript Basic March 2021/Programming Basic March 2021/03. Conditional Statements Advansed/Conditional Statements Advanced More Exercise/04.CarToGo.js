function carToGo(input) {
    let budget = Number(input[0]);
    let season = input[1].toLowerCase();

    let carType = season === "summer" ? "Cabrio" : "Jeep";
    let carClass = null;
    let carPrice = null;

    if (budget <= 100) {
        carClass = "Economy class";
        carPrice = season === "summer" ? budget * 0.35 : budget * 0.65;

    }else if (budget <= 500) {
        carClass = "Compact class";
        carPrice = season === "summer" ? budget * 0.45 : budget * 0.80;

    }else {
        carClass = "Luxury class";
        carType = "Jeep";
        carPrice = budget * 0.90;
    }
    console.log(`${carClass}\n` + `${carType} - ${carPrice.toFixed(2)}`);
}
carToGo(["450", "Summer"]);

carToGo(["450", "Winter"]);

carToGo(["1010", "Summer"]);

carToGo(["99.99", "Summer"]);

carToGo(["1010", "Winter"]);

carToGo(["70.50", "Winter"]);