function getLastElements(arrayLength, numbersCount){
    let elements = [];
    elements[0] = 1;

    while (elements.length < arrayLength) {
        let elementToPush = elements
            .slice(-numbersCount)  
            .reduce((a, b) => a + b, 0);
        
        elements.push(elementToPush);
    }

    return elements;
}

console.log(getLastElements(6, 3));
console.log(getLastElements(8, 2));