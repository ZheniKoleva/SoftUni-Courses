function cinemaTicket(input) {
    let dayOfWeek = input[0].toLowerCase();

    let ticketPrice = 0.00;
    switch (dayOfWeek) {
        case "monday":
        case "tuesday":
        case "friday":
            ticketPrice = 12; break;
        case "wednesday":
        case "thursday":
            ticketPrice = 14; break;
        case "saturday":
        case "sunday":
            ticketPrice = 16; break;
    }
    console.log(ticketPrice);
}
cinemaTicket(["Monday"]);
cinemaTicket(["Friday"]);
cinemaTicket(["Sunday"]);