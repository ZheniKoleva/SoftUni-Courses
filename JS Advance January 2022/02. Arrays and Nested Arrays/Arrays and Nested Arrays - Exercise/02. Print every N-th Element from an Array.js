function printArray(inputArray, number) {
    return inputArray
        .filter((x, i) => i % number == 0);
}

console.log(printArray(['5', '20', '31', '4', '20'], 2));

console.log(printArray(['dsa', 'asd', 'test', 'tset'], 2));

console.log(printArray(['1', '2', '3', '4', '5'], 6));