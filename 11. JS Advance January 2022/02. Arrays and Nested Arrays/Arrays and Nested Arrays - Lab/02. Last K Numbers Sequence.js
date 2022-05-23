function lastKNumbers(arrayLength, number){
    const resultArray = [];
    resultArray.push(1);

    while (resultArray.length < arrayLength) {
        const nextElement = resultArray
            .slice(-number)
            .reduce((a,b) => a + b, 0);
        
            resultArray.push(nextElement);
    }

    return resultArray;
}

console.log(lastKNumbers(6, 3));
console.log(lastKNumbers(8, 2));