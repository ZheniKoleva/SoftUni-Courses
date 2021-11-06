function skiTrip(input) {
    let daysCount = parseInt(input[0]);
    let roomType = input[1];
    let evaluation = input[2];

    let night = daysCount - 1;
    let pricePerNight = 0.00;

    switch (roomType) {
        case "room for one person":
            pricePerNight = 18.00; break;
        case "apartment":
            pricePerNight = 25.00; break;
        case "president apartment":
            pricePerNight = 35.00; break;
    }

    let totalPrice = pricePerNight * night;

    if (daysCount < 10) {
        switch (roomType) {
            case "apartment":
                totalPrice -= totalPrice * 0.30; break;
            case "president apartment":
                totalPrice -= totalPrice * 0.10; break;
        }

    } else if (daysCount <= 15) {
        switch (roomType) {
            case "apartment":
                totalPrice -= totalPrice * 0.35; break;
            case "president apartment":
                totalPrice -= totalPrice * 0.15; break;
        }

    } else if (daysCount > 15) {
        switch (roomType) {
            case "apartment":
                totalPrice -= totalPrice * 0.50; break;
            case "president apartment":
                totalPrice -= totalPrice * 0.20; break;
        }
    }

    if (evaluation === "positive") {
        totalPrice += totalPrice * 0.25;
    }else {
        totalPrice -= totalPrice * 0.10;
    }

    console.log(totalPrice.toFixed(2));
}
skiTrip(["14", "apartment", "positive"]);

skiTrip(["30", "president apartment", "negative"]);

skiTrip(["12", "room for one person", "positive"]);

skiTrip(["2", "apartment", "positive"]);


