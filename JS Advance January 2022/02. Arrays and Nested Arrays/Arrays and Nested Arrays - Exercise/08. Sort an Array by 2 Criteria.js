function sortArray(inputArray) {
    debugger
    inputArray
        .sort((a, b) => (a.length) - (b.length) || a.localeCompare(b))
        .forEach(x => console.log(x));
}

sortArray(['alpha', 'beta', 'gamma']);

sortArray(['Isacc', 'Theodor', 'Jack', 'Harrison', 'George']);

sortArray(['test', 'Deny', 'omen', 'Default']);