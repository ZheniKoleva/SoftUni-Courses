function createCalorieObject(inputArray){
    const resultObject = {};

    for (let index = 0; index < inputArray.length; index += 2) {
        resultObject[inputArray[index]] = Number(inputArray[index + 1]);        
    }
    
    console.log(resultObject);
}

createCalorieObject(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);
createCalorieObject(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']);