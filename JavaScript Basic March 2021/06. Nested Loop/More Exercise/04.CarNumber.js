function luckyNumbers(input) {
    let start = parseInt(input[0]);
    let end = parseInt(input[1]);

    let result = "";

    for (let d1 = start; d1 <= end; d1++) {
        for (let d2 = start; d2 <= end; d2++) {
            for (let d3 = start; d3 <= end; d3++) {
                for (let d4 = start; d4 <= end; d4++) {

                    let isEvenFirst = ((d1 % 2 === 0) && (d4 % 2 === 1));
                    let isEvenLast = ((d1 % 2 === 1) && (d4 % 2 === 0));

                    let isValid = isEvenFirst || isEvenLast;
                    let isFirstBigger = d1 > d4;
                    let isSumEven = (d2 + d3) % 2 === 0;

                    if (isValid && isFirstBigger && isSumEven) {
                        result += (`${d1}${d2}${d3}${d4} `);
                    }
                }
           }           
        }        
    }

    console.log(result);
}
luckyNumbers(["2", "3"]);
luckyNumbers(["3", "5"]);
luckyNumbers(["5", "8"]);