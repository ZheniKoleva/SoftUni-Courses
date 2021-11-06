function cinema(input) {
    let projectionType = input[0].toLowerCase();
    let seats = parseInt(input[1]) * parseInt(input[2]);

    let ticketPrice = 0.00;

    switch (projectionType) {
        case "premiere":
            ticketPrice = 12.00;
            break;
        case "normal":
            ticketPrice = 7.50;
            break;
        case "discount":
            ticketPrice = 5.00;
            break;
    }
    let totalPrice = seats * ticketPrice;
    console.log(`${totalPrice.toFixed(2)} leva`);
}
cinema(["Premiere",
    "10",
    "12"]);

cinema(["Normal",
    "21",
    "13"]);

cinema(["Discount",
    "12",
    "30"]);


