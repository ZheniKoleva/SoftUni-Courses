function schoolCamp(input) {
    let season = input[0].toLowerCase();
    let groupType = input[1];
    let studentsCount = parseInt(input[2]);
    let nightsCount = parseInt(input[3]);

    let pricePerNight = 0;
    let sport = null;

    switch (season) {
        case "winter":
            if (groupType === "mixed") {
                pricePerNight = 10.00;

            } else {
                pricePerNight = 9.60;
            }

            if (groupType === "girls") {
                sport = "Gymnastics";

            } else if (groupType === "boys") {
                sport = "Judo";

            } else {
                sport = "SKi";
            }

            break;
        case "spring":
            if (groupType === "mixed") {
                pricePerNight = 9.50;

            } else {
                pricePerNight = 7.20;
            }

            if (groupType === "girls") {
                sport = "Athletics";

            } else if (groupType === "boys") {
                sport = "Tennis";

            } else {
                sport = "Cycling";
            }
            break;
        case "summer":
            if (groupType === "mixed") {
                pricePerNight = 20.00;

            } else {
                pricePerNight = 15.00;
            }

            if (groupType === "girls") {
                sport = "Volleyball";

            } else if (groupType === "boys") {
                sport = "Football";
                
            } else {
                sport = "Swimming";
            }
            break;
    }

    let totalPrice = studentsCount * pricePerNight * nightsCount;
    if (studentsCount >= 50) {
        totalPrice -= totalPrice * 0.50;

    }else if (studentsCount >= 20 && studentsCount < 50) {
        totalPrice -= totalPrice * 0.15;

    }else if (studentsCount >= 10 && studentsCount < 20) {
        totalPrice -= totalPrice * 0.05
    }
    console.log(`${sport} ${totalPrice.toFixed(2)} lv.`);
}
schoolCamp(["Spring", "girls", "20", "7"]);
schoolCamp(["Winter", "mixed", "9", "15"]);
schoolCamp(["Summer", "boys", "60", "7"]);
schoolCamp(["Spring", "mixed", "17", "14"]);