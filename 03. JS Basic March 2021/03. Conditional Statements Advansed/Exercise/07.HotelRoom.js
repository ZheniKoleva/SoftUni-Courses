function hotelRoom(input) {
    let month = input[0].toLowerCase();
    let nightsCount = parseInt(input[1]);

    let studioPrice = 0.00;
    let apartmentPrice = 0.00;

    switch (month) {
        case "may":
        case "october":
            studioPrice = nightsCount * 50;
            apartmentPrice = nightsCount * 65;
            if (nightsCount > 7 && nightsCount <= 14) {
                studioPrice -= studioPrice * 0.05;

            }else if (nightsCount > 14) {
                studioPrice -= studioPrice * 0.30;
                apartmentPrice -= apartmentPrice * 0.10;
            }
            break;
        case "june":
        case "september":
            studioPrice = nightsCount * 75.20;
            apartmentPrice = nightsCount * 68.70;
            if (nightsCount > 14) {
                studioPrice -= studioPrice * 0.20;
                apartmentPrice -= apartmentPrice * 0.10;
            }
           break;
        case "july":
        case "august":
            studioPrice = nightsCount * 76;
            apartmentPrice = nightsCount * 77;
            if (nightsCount > 14) {
                apartmentPrice -= apartmentPrice * 0.10;
            }
            break;
    }
    console.log(`Apartment: ${apartmentPrice.toFixed(2)} lv.\n` + 
                `Studio: ${studioPrice.toFixed(2)} lv.`);
}
hotelRoom(["May", "15"]);

hotelRoom(["June", "14"]);

hotelRoom(["August", "20"]);


