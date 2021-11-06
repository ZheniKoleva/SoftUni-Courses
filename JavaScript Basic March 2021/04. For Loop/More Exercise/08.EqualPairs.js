function equalPairs(input) {
    let index = 0;
    let pairsCount = parseInt(input[index++]);

    let previousSum = 0;
    let maxDifference = 0;    
    
    for (let pair = 1; pair <= pairsCount; pair++) {
        let num1 = parseInt(input[index++]);
        let num2 = parseInt(input[index++])

        let currentSum = num1 + num2;            

        if (previousSum == 0) {
            previousSum = currentSum;

        } else {
            let currentDiff = Math.abs(currentSum - previousSum);

            if (currentDiff > maxDifference) {
                maxDifference = currentDiff;
            }
            previousSum = currentSum;            
        }
    }

    if (maxDifference == 0) {
        console.log(`Yes, value=${previousSum}`);

    } else {
        console.log(`No, maxdiff=${maxDifference}`);
    }
}
equalPairs(["3", "1", "2", "0", "3", "4", "-1"]);
equalPairs(["4", "1", "1", "3", "1", "2", "2", "0", "0"]);
equalPairs(["2", "-1", "0", "0", "-1"]);
equalPairs(["2", "1", "2", "2", "2"]);
equalPairs(["1", "5", "5"]);
equalPairs(["2", "-1", "2", "0", "-1"]);