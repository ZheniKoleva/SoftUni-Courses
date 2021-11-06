function accountBalance(input) {
    let index = 0;
    let command = input[index];
    
    let isNegative = false;
    let totalSum = 0.00;

    while (command !== "NoMoreMoney") {
        let currentSum = Number(input[index++]);
        if (currentSum < 0) {
            isNegative = true;
            break;
        }
        console.log(`Increase: ${currentSum.toFixed(2)}`);
        totalSum += currentSum;
        command = input[index];
    }

    if (isNegative) {
        console.log("Invalid operation!")
    }
    console.log(`Total: ${totalSum.toFixed(2)}`);    
}
accountBalance(["5.51", 
"69.42",
"100",
"NoMoreMoney"]);
console.log(`-----------------`);
accountBalance(["120",
"45.55",
"-150"]);

