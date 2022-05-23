function aggregateElements(input){
    let sum = input.reduce((a, b) => a + b);
    let inverseSum = input.reduce((a, b) => a + 1 / b, 0);
    let concatString = input.join('');

    console.log(sum);
    console.log(inverseSum);    
    console.log(concatString);
}

aggregateElements([1, 2, 3]);
aggregateElements([2, 4, 8, 16]);