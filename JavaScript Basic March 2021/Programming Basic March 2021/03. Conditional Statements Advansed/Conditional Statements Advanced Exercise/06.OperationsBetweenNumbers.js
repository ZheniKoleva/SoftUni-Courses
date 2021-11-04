function operationsBetweenNumbers(input) {
    let num1 = Number(input[0]);
    let num2 = Number(input[1]);
    let operator = input[2];

    if (num2 === 0 && (operator === '/' || operator === '%')) {
        console.log(`Cannot divide ${num1} by zero`)
        return;
    }
    let result = 0.00;

    switch (operator) {
        case '+':
            result = num1 + num2; break;
        case '-':
            result = num1 - num2; break;
        case '*':
            result = num1 * num2; break;
        case '/':
            result = num1 / num2; break;
        case '%':
            result = num1 % num2; break;
    }

    if (operator === '+' || operator === '-' || operator === '*') {
        let isEvenOrOdd = result % 2 === 0 ? "even" : "odd";
        console.log(`${num1} ${operator} ${num2} = ${result} - ${isEvenOrOdd}`);

    } else if (operator === '/') {
        console.log(`${num1} ${operator} ${num2} = ${result.toFixed(2)}`);

    }else {
        console.log(`${num1} ${operator} ${num2} = ${result}`);
    }
}
operationsBetweenNumbers(["10", "12", "+"]);

operationsBetweenNumbers(["10", "1", "-"]);

operationsBetweenNumbers(["7", "3", "*"]);

operationsBetweenNumbers(["123", "12", "/"]);

operationsBetweenNumbers(["10", "3", "%"]);

operationsBetweenNumbers(["112", "0", "/"]);

operationsBetweenNumbers(["10", "0", "%"]);








