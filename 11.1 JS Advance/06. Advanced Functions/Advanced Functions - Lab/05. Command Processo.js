function solution(){    
    let result = '';

    return {
        append: (input) => result = result.concat(input),
        removeStart: (symbolsCount) => result = result.substring(symbolsCount),
        removeEnd: (symbolsCount) => result = result.substring(0, result.length - symbolsCount),
        print: () => console.log(result)
    };
}


let firstZeroTest = solution();

firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();

console.log('===================');

let secondZeroTest = solution();

secondZeroTest.append('123');
secondZeroTest.append('45');
secondZeroTest.removeStart(2);
secondZeroTest.removeEnd(1);
secondZeroTest.print();

