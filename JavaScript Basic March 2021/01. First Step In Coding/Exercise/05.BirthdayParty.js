function birthdayParty(input) {
    let rent = Number(input[0]);

    let cakePrice = rent * 0.20;
    let drinksPrice = cakePrice * 0.55;
    let animator = rent / 3;

    let totalSum = rent + cakePrice + drinksPrice + animator;
    console.log(totalSum);
}
birthdayParty(["2250"]);
birthdayParty(["3720"]);