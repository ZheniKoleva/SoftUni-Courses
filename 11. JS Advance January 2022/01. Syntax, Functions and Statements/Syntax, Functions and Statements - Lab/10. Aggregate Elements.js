function aggregateElements(input) {
    let sum = 0;
    let inverseSum = 0;
    let concatString = '';

    input.forEach(x => {
        sum += x;
        inverseSum += 1 / x;
        concatString += x;
    });

    console.log(sum);
    console.log(inverseSum);
    console.log(concatString);
}

aggregateElements([1, 2, 3]);
aggregateElements([2, 4, 8, 16]);