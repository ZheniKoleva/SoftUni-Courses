function sortArray(inputArray, orderType) {
    const sort = {
        asc: (inputArray) => inputArray.sort((a, b) => a - b),
        desc: (inputArray) => inputArray.sort((a, b) => b - a)
    };

    return sort[orderType](inputArray);
}

console.log(sortArray([14, 7, 17, 6, 8], 'asc'));
console.log(sortArray([14, 7, 17, 6, 8], 'desc'));