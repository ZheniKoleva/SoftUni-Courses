function flowers(input) {
    let chrysanthemumCount = parseInt(input[0]);
    let roseCount = parseInt(input[1]);
    let tulipCount = parseInt(input[2]);
    let season = input[3].toLowerCase();
    let holiday = input[4];

    let flowerCount = chrysanthemumCount + roseCount + tulipCount;
    let bouquetArrangement = 2.00;
    let chrysanthemumPrice = 0.00;
    let rosePrice = 0.00;
    let tulipPrice = 0.00;

    switch (season) {
        case "spring":
        case "summer":
            chrysanthemumPrice = 2.00;
            rosePrice = 4.10;
            tulipPrice = 2.50;
            break;
        case "autumn":
        case "winter":
            chrysanthemumPrice = 3.75;
            rosePrice = 4.50;
            tulipPrice = 4.15;
            break;
    }

    let bouquetPrice = (chrysanthemumPrice * chrysanthemumCount) +
        (rosePrice * roseCount) + (tulipPrice * tulipCount);

    if (holiday === "Y") {
        bouquetPrice *= 1.15;
    }

    if (tulipCount > 7 && season === "spring") {
        bouquetPrice -= bouquetPrice * 0.05;
    }

    if (roseCount >= 10 && season === "winter") {
        bouquetPrice -= bouquetPrice * 0.10;
    }

    if (flowerCount > 20) {
        bouquetPrice -= bouquetPrice * 0.20;
    }
    bouquetPrice += bouquetArrangement;
    console.log(bouquetPrice.toFixed(2));
}
flowers(["2", "4", "8", "Spring", "Y"]);

flowers(["3", "10", "9", "Winter", "N"]);

flowers(["10", "10", "10", "Autumn", "N"]);