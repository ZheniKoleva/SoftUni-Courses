function sortNumbers(inputArray) {    
    inputArray.sort((a, b) => a - b);
    
    for (let index = 0; index < inputArray.length; index += 2) {
       const maxElement = inputArray.pop();

       inputArray.splice(index + 1, 0, maxElement);
    }

    return inputArray;
}

console.log(sortNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));