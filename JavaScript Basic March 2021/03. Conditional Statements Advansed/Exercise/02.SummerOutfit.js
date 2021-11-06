function summerOutfit(input) {
    let degrees = parseInt(input[0]);

    let outfit = null;
    let shoes = null;

    switch (input[1].toLowerCase()) {
        case "morning":
            if (degrees <= 18) {
                outfit = "Sweatshirt";
                shoes = "Sneakers";

            } else if (degrees <= 24) {
                outfit = "Shirt";
                shoes = "Moccasins";

            } else if (degrees >= 25) {
                outfit = "T-Shirt";
                shoes = "Sandals";
            }

            break;

        case "afternoon":
            if (degrees <= 18) {
                outfit = "Shirt";
                shoes = "Moccasins";

            } else if (degrees <= 24) {
                outfit = "T-Shirt";
                shoes = "Sandals";

            } else if (degrees >= 25) {
                outfit = "Swim Suit";
                shoes = "Barefoot";
            }

            break;

        case "evening":
            outfit = "Shirt";
            shoes = "Moccasins";
            break;
    }
    let output = `It's ${degrees} degrees, get your ${outfit} and ${shoes}.`;
    console.log(output);
}
summerOutfit(["16",
    "Morning"]);

summerOutfit(["22",
    "Afternoon"]);

summerOutfit(["28",
    "Evening"]);


