function sumFirstAndLastElement(inputArray){
    return Number(inputArray[0]) + Number(inputArray[inputArray.length - 1]);
}

console.log(sumFirstAndLastElement(['20', '30', '40']));
console.log(sumFirstAndLastElement(['5', '10']));