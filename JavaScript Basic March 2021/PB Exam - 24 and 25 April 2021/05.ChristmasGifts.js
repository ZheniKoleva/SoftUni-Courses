function christmasGifts(input) {
    let index = 0;
    let command = input[index++];

    let kidsCount = 0;
    let adultsCount = 0;
    let toysCount = 0;
    let sweatersCount = 0;
    const toyPrice = 5;
    const sweaterPrice = 15;

    while (command !== "Christmas") {
        let age = parseInt(command);

        if (age <= 16) {
            kidsCount++;
            toysCount++;

        } else {
            adultsCount++;
            sweatersCount++;
        }
        command = input[index++];
    }

    let toysTotalPrice = toysCount * toyPrice;
    let sweatersTotalPrice = sweatersCount * sweaterPrice;

    console.log(`Number of adults: ${adultsCount}\n`
        + `Number of kids: ${kidsCount}`);
    console.log(`Money for toys: ${toysTotalPrice}\n`
        + `Money for sweaters: ${sweatersTotalPrice}`);
}
christmasGifts(["16",
"20",
"46",
"12",
"8",
"20",
"49",
"Christmas"]);

christmasGifts(["16",
"16",
"16",
"16",
"16",
"Christmas"]);

christmasGifts(["18",
"20",
"48",
"45",
"56",
"37",
"12",
"14",
"Christmas"]);


