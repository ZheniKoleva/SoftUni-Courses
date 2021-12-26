function processOddPositions(inputArray){
    let processedArray = inputArray
        .filter((x, i) => i % 2 == 1)
        .map(x => x * 2)
        .reverse()
        .join(' ');

    return processedArray;
}

console.log(processOddPositions([10, 15, 20, 25]));
console.log(processOddPositions([3, 0, 10, 4, 7, 3]));