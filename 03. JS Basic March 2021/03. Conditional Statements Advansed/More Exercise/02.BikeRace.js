function bikeRace(input) {
    let juniors = parseInt(input[0]);
    let seniors = parseInt(input[1]);
    let roadType = input[2];

    let cyclistsTotal = juniors + seniors;
    let juniorFee = 0.00;
    let seniorFee = 0.00;

    switch (roadType) {
        case "trail":
            juniorFee = 5.50;
            seniorFee = 7.00;
            break;
        case "cross-country":
            juniorFee = 8.00;
            seniorFee = 9.50;
            break;
        case "downhill":
            juniorFee = 12.25;
            seniorFee = 13.75;
            break;
        case "road":
            juniorFee = 20.00;
            seniorFee = 21.50;
            break;
    }

    let totalSum = (juniorFee * juniors) + (seniorFee * seniors);

    if (cyclistsTotal >= 50 && roadType === "cross-country") {
        totalSum -= totalSum * 0.25;
    }
    totalSum -= totalSum * 0.05;
    console.log(totalSum.toFixed(2));
}
bikeRace(["10", "20", "trail"]);

bikeRace(["20", "25", "cross-country"]);

bikeRace(["30", "25", "cross-country"]);

bikeRace(["10", "10", "downhill"]);

bikeRace(["3", "40", "road"]);