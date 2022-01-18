function catLife(input) {
    let catBreed = input[0];
    let catGender = input[1];

    let yearsMaxLiving = 0;

    switch (catBreed) {
        case "British Shorthair":
            if (catGender === 'm') {
                yearsMaxLiving = 13;

            } else {
                yearsMaxLiving = 14;
            }
            break;

        case "Siamese":
            if (catGender === 'm') {
                yearsMaxLiving = 15;

            } else {
                yearsMaxLiving = 16;
            }
            break;

        case "Persian":
            if (catGender === 'm') {
                yearsMaxLiving = 14;

            } else {
                yearsMaxLiving = 15;
            }
            break;

        case "Ragdoll":
            if (catGender === 'm') {
                yearsMaxLiving = 16;

            } else {
                yearsMaxLiving = 17;
            }
            break;

        case "American Shorthair":
            if (catGender === 'm') {
                yearsMaxLiving = 12;

            } else {
                yearsMaxLiving = 13;
            }
            break;

        case "Siberian":
            if (catGender === 'm') {
                yearsMaxLiving = 11;

            } else {
                yearsMaxLiving = 12;
            }
            break;

        default:
            console.log(`${catBreed} is invalid cat!`)
            break;
    }

    if (yearsMaxLiving != 0) {
        let yearsEqualToHumans = yearsMaxLiving * 12;
        let catMonths = Math.floor(yearsEqualToHumans / 6);
        console.log(`${catMonths} cat months`);
    }
}
catLife(["Persian",
"m"]);

catLife(["Siamese",
"f"]);

catLife(["Siberian",
"m"]);

catLife(["Ragdoll",
"f"]);

catLife(["Tom",
"m"]);

