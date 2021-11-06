function sumOfTwoNumbers(input) {
    let start = parseInt(input.shift());
    let end = parseInt(input.shift());
    let magicNumber = parseInt(input.shift());

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
sumOfTwoNumbers(["1", "10", "5"]);
sumOfTwoNumbers(["23", "24", "20"]);
sumOfTwoNumbers(["88", "888", "1000"]);
sumOfTwoNumbers(["88", "888", "2000"]);