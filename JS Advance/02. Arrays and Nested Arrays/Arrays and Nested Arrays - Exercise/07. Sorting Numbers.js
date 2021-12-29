function sortNumber(inputArray){
    inputArray.sort((a, b) => a - b);

    for (let index = 0; index < inputArray.length; index += 2) {        
        let lastElement = inputArray.pop();

        inputArray.splice(index + 1, 0, lastElement);
    }
    
    return inputArray;
}

console.log(sortNumber([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));
