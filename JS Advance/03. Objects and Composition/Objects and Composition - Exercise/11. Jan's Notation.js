function jansNotation(inputArray){
    const numbers = [];

    for (const value of inputArray) {
        if (Number.isInteger(value)) {
            numbers.push(value);
            continue;
        }

        let operator = value;

        if (numbers.length < 2) {
            return 'Error: not enough operands!';
        }

        let secondDigit = numbers.pop();
        let firstDigit = numbers.pop();

        let currentResult = calculateResult(firstDigit, secondDigit, operator);
        numbers.push(currentResult);

    }

    return numbers.length === 1 ? numbers[0] : 'Error: too many operands!';

    function calculateResult(first, second, operator){
        const operations = {
            '+': () => first + second,
            '-': () => first - second,
            '/': () => first / second,
            '*': () => first * second, 
        }

        return operations[operator]();
    }

}

console.log(jansNotation([3, 4,'+']));

console.log(jansNotation([5, 3, 4, '*', '-']));

console.log(jansNotation([7, 33, 8,'-']));

console.log(jansNotation([15,'/']));