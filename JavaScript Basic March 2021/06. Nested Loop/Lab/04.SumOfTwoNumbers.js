function sumOfNumbers(input) {
    let start = parseInt(input[0]);
    let end = parseInt(input[1]);
    let magicNumber = parseInt(input[2]);

    let combinationCount = 0;
    let flag = false;

    for (let digit1 = start; digit1 <= end; digit1++) {
        for (let digit2 = start; digit2 <= end; digit2++) {
            
            combinationCount++;
            let isValidCombination = (digit1 + digit2) === magicNumber;

            if (isValidCombination) {
                console.log(`Combination N:${combinationCount} (${digit1} + ${digit2} = ${magicNumber})`);
                flag = true;
                break;
            }
        }
        
        if (flag) {
            break;
        }
    }

    if (!flag) {
        console.log(`${combinationCount} combinations - neither equals ${magicNumber}`);        
    }
}
sumOfNumbers(["1", "10", "5"]);
sumOfNumbers(["23", "24", "20"]);
sumOfNumbers(["88", "888", "1000"]);
sumOfNumbers(["88", "888", "2000"]);
