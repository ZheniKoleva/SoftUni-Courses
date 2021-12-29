function rotateArray(inputArray, rotationsCount){

    for (let rotation = 0; rotation < rotationsCount; rotation++) {
        let lastElement = inputArray.pop();

        inputArray.unshift(lastElement);
    }

    console.log(inputArray.join(' '));
}

rotateArray(['1', 
'2', 
'3', 
'4'], 
2);

rotateArray(['Banana', 
'Orange', 
'Coconut', 
'Apple'], 
15);