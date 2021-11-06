function matchTickets(input) {
    let budget = Number(input[0]);
    let ticketCategory = input[1];
    let peopleCount = parseInt(input[2]);

    let ticketPrice = 0.00;

    switch (ticketCategory) {
        case "VIP":
            ticketPrice = 499.99;
            ticketPrice *= peopleCount;
            break;
        case "Normal":
            ticketPrice = 249.99;
            ticketPrice *= peopleCount;
            break;
    }

    if (peopleCount <= 4) {
        budget -= budget * 0.75;

    } else if (peopleCount <= 9) {
        budget -= budget * 0.60;

    } else if (peopleCount <= 24) {
        budget -= budget * 0.50;

    } else if (peopleCount <= 49) {
        budget -= budget * 0.40;

    } else {
        budget -= budget * 0.25;
    }

    let difference = Math.abs(budget - ticketPrice).toFixed(2);
    if (budget >= ticketPrice) {
        console.log(`Yes! You have ${difference} leva left.`);

    } else {
        console.log(`Not enough money! You need ${difference} leva.`);
    }
}
matchTickets(["1000", "Normal", "1"]);

matchTickets(["30000", "VIP", "49"]);