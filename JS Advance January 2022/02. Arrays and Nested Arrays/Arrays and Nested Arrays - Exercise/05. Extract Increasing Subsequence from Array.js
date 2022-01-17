function extractIncreasingArray(inputArray) {
    let resultArray = [];

    inputArray.reduce((resultArray, b) => {
        if (resultArray.length == 0
            || resultArray[resultArray.length - 1] <= b) {
            resultArray.push(b);
        }

        return resultArray;

    }, resultArray);

    return resultArray;
}

console.log(extractIncreasingArray([1, 3, 8, 4, 10, 12, 3, 2, 24]));

console.log(extractIncreasingArray([1, 2, 3, 4]));

console.log(extractIncreasingArray([20, 3, 2, 15, 6, 1]));