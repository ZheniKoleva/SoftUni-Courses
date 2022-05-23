function printElements(inputArray, step){
    let resultArray = inputArray
        .filter((x, i) => i % step == 0);

    return resultArray;
}

console.log(printElements(['5', 
'20', 
'31', 
'4', 
'20'],
2));

console.log(printElements(['dsa',
'asd', 
'test', 
'tset'], 
2));

console.log(printElements(['1', 
'2',
'3', 
'4', 
'5'], 
6));