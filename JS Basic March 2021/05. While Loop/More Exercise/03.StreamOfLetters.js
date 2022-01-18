function streamOfLetter(input) {
    let index = 0;
    let hasC = false;
    let hasO = false;
    let hasN = false;

    let currentWord = "";
    let finalWord = "";

    let command = input[index++];

    while (command !== "End") {
        let currentSymbol = command;

        switch (currentSymbol) {
            case 'c':
                if (hasC) {
                    currentWord += currentSymbol;
                } else {
                    hasC = true;
                }
                break;

            case 'o':
                if (hasO) {
                    currentWord += currentSymbol;
                } else {
                    hasO = true;
                }
                break;

            case 'n':
                if (hasN) {
                    currentWord += currentSymbol;
                } else {
                    hasN = true;
                }
                break;

            default:
                if ((currentSymbol >= 'A' && currentSymbol <= 'Z')
                    || (currentSymbol >= 'a' && currentSymbol <= 'z')) {

                    currentWord += currentSymbol;
                } 
                break;
        }

        if (hasC && hasO && hasN) {
            currentWord += " ";
            finalWord += currentWord;
            currentWord = "";
            hasC = false;
            hasO = false;
            hasN = false;
        }

        command = input[index++];
    }

    console.log(finalWord);
}
streamOfLetter(["H", "n", "e", "l", "l", "o", "o", "c", "t", "c", "h", "o", "e", "r", "e", "n", "e", "End"]);
streamOfLetter(["%", "!", "c", "^", "B", "`", "o", "%", "o", "o", "M", ")", "{", "n", "\\", "A", "D", "End"]);
streamOfLetter(["o", "S", "%", "o", "l", "^", "v", "e", "c", "n", "&", "m", "e", "c", "o", "n", "End"]);