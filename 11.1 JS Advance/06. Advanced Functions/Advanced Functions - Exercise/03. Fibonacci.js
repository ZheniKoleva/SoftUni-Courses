function getFibonator() {
    let startNumber = 0;
    let step = 1;
    let currentNumber = 0;

    const fib = function () {
        startNumber = step;
        step = currentNumber;
        currentNumber = startNumber + step;

        return currentNumber;
    };

    return fib;
}

let fib = getFibonator();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8
console.log(fib()); // 13
