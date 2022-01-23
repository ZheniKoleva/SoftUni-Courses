function jansNotation(inputArray) {
    const operations = {
        '+': (a, b) => a + b,
        '-': (a, b) => a - b,
        '*': (a, b) => a * b,
        '/': (a, b) => a / b,
    };

    const result = []; 

    for (const element of inputArray) {
        if (Number.isInteger(element)) {
            result.push(element);
            continue;
        }

        if (result.length < 2) {
            return 'Error: not enough operands!';
        }

        let secondDigit = result.pop();
        let firstDigit = result.pop();
                
        result.push(operations[element](firstDigit, secondDigit));
    }

    return result.length === 1
        ? result[0]
        : 'Error: too many operands!';
}

console.log(jansNotation([3, 4,'+']));

console.log(jansNotation([5, 3, 4, '*', '-']));

console.log(jansNotation([7, 33, 8, '-']));

console.log(jansNotation([15,'/']));