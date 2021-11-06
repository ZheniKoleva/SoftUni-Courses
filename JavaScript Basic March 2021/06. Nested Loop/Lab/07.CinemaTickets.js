function cinemaTickets(input) {
    let movieName = input.shift();

    let ticketsTotal = 0;
    let studentTickets = 0;
    let standardTickets = 0;
    let kidTickets = 0;

    while (movieName !== "Finish") {
        let freeSeats = parseInt(input.shift());
        let seatsTaken = 0;
        let ticketType = input.shift();

        while (ticketType !== "End") {

            switch (ticketType) {
                case "student":
                    studentTickets++;
                    break;
                case "standard":
                    standardTickets++;
                    break;
                case "kid":
                    kidTickets++;
                    break;
            }
            ticketsTotal++;
            seatsTaken++;
            if (seatsTaken === freeSeats) {
                break;
            }
            ticketType = input.shift();

        }
        let percentageFull = (seatsTaken / freeSeats) * 100.00;
        console.log(`${movieName} - ${percentageFull.toFixed(2)}% full.`);
        movieName = input.shift();
    }

    let percentStudent = (studentTickets / ticketsTotal) * 100.00;
    let percentStandard = (standardTickets / ticketsTotal) * 100.00;
    let percentSKid = (kidTickets / ticketsTotal) * 100.00;
    console.log(`Total tickets: ${ticketsTotal}`);
    console.log(`${percentStudent.toFixed(2)}% student tickets.\n`
        + `${percentStandard.toFixed(2)}% standard tickets.\n`
        + `${percentSKid.toFixed(2)}% kids tickets.`)
}
cinemaTickets(["Taxi",
"10",
"standard",
"kid",
"student",
"student",
"standard",
"standard",
"End",
"Scary Movie",
"6",
"student",
"student",
"student",
"student",
"student",
"student",
"Finish"]);

cinemaTickets(["The Matrix",
"20",
"student",
"standard",
"kid",
"kid",
"student",
"student",
"standard",
"student",
"End",
"The Green Mile",
"17",
"student",
"standard",
"standard",
"student",
"standard",
"student",
"End",
"Amadeus",
"3",
"standard",
"standard",
"standard",
"Finish"]);
