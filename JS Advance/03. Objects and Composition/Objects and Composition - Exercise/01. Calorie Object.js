function createCalorieObject(inputArray){
    const result = {};

    for (let index = 0; index < inputArray.length; index += 2) {
       const productName = inputArray[index];
       const calories = Number(inputArray[index + 1]);

       result[productName] = calories;        
    }

   console.log(result);
}

createCalorieObject(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);

createCalorieObject(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']);