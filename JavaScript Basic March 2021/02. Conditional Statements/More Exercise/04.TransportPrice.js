function transportPrice(input) {
    let distance = parseInt(input[0]);
    let periodOfDay = input[1];

    let taxiRate = 0.00;
    const initialTaxiFee = 0.70;
    const busRate = 0.09;
    const trainRate = 0.06;
    let totalSum = 0.00;

    if (periodOfDay === "day") {
        taxiRate = 0.79;
    } else {
        taxiRate = 0.90;
    }

    if (distance < 20) {
        totalSum = initialTaxiFee + (distance * taxiRate);

    } else if (distance < 100) {
        totalSum = distance * busRate;

    }else {
        totalSum = distance * trainRate;
    }

    console.log(totalSum.toFixed(2));
}
transportPrice(["5", "day"]);
transportPrice(["7", "night"]);
transportPrice(["25", "day"]);
transportPrice(["180", "night"]);