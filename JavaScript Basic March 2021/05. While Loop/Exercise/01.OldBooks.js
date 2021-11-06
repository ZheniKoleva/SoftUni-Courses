function oldBooks(input) {
    let index = 0;
    let bookSearched = input[index++];

    let isFound = false;
    let bookCount = 0;
    let command = input[index++];

    while (command !== "No More Books") {

        if (command == bookSearched) {
            isFound = true;
            break;
        }
        bookCount++;
        command = input[index++];
    }

    if (isFound) {
        console.log(`You checked ${bookCount} books and found it.`);

    } else {
        console.log("The book you search is not here!\n"
            + `You checked ${bookCount} books.`)
    }
}
oldBooks(["Troy", "Stronger", "Life Style", "Troy"]);
oldBooks(["The Spot", "Hunger Games", "Harry Potter", "Torronto", "Spotify", "No More Books"]);
oldBooks(["Bourne", "True Story", "Forever", "More Space", "The Girl", "Spaceship", "Strongest",
    "Profit", "Tripple", "Stella", "The Matrix", "Bourne"]);