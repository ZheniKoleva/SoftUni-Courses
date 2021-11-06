function reportSystem(input) {
    let index = 0;
    let sumToCollect = parseInt(input[index++]);

    let paidInCash = 0;
    let paidInCashCount = 0;
    let paidByCard = 0;
    let paidByCardCount = 0;
    let transactionsCount = 0;
    let totalSum = 0;
    let isCollect = false;

    let command = input[index];
    while (command !== "End") {
        let currentSum = parseInt(input[index++]);
        transactionsCount++;

        if (transactionsCount % 2 == 1) {
            if (currentSum > 100 ) {
                console.log(`Error in transaction!`);

            }else {
                paidInCashCount++;
                paidInCash += currentSum;
                totalSum += currentSum;
                console.log("Product sold!");               
            }

        }else {
            if (currentSum < 10 ) {
                console.log(`Error in transaction!`);

            }else {
                paidByCardCount++; 
                paidByCard += currentSum;
                totalSum += currentSum;
                console.log("Product sold!");                               
            }
        }

        if (totalSum >= sumToCollect) {
            isCollect = true;
            break;
        }
        command = input[index];
    }

    if (isCollect) {
        console.log(`Average CS: ${(paidInCash / paidInCashCount).toFixed(2)}\n`
            + `Average CC: ${(paidByCard / paidByCardCount).toFixed(2)}`);

    } else {
        console.log("Failed to collect required money for charity.")
    } 
   
}
reportSystem(["500", "120", "8", "63", "256", "78", "317"]);
console.log(`------------------`);
reportSystem(["600", "86", "150", "98", "227", "End"]);