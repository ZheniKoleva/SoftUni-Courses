function mathOperations(firstDigit, secondDigit, operator){
    const operations = {
        '+': (a, b) => a + b,
        '-': (a, b) => a - b,
        '*': (a, b) => a * b,
        '/': (a, b) => a / b,
        '%': (a, b) => a % b,
        '**': (a, b) => a ** b
    }; 

    const result = operations[operator](firstDigit, secondDigit);
    console.log(result);
}

mathOperations(5, 6, '+');
mathOperations(3, 5.5, '*')