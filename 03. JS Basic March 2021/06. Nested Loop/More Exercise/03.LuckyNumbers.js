function luckyNumbers(input) {
    let number = parseInt(input[0]);

    let result = "";

    for (let d1 = 1; d1 <= 9; d1++) {
        for (let d2 = 1; d2 <= 9; d2++) {
            for (let d3 = 1; d3 <= 9; d3++) {
                for (let d4 = 1; d4 <= 9; d4++) {

                    let isValidSum = ((d1 + d2) === (d3 + d4));
                    let isEven = (number % (d1 + d2) === 0);
                    
                    if (isValidSum && isEven) {
                        result += (`${d1}${d2}${d3}${d4} `);
                    }
                }
            }
        }
    }

    console.log(result);
}
luckyNumbers(["3"]);
luckyNumbers(["7"]);
luckyNumbers(["24"]);