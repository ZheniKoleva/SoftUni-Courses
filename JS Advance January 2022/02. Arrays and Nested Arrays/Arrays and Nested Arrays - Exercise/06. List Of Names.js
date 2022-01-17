function sortArray(inputArray) {
    inputArray.sort((a, b) => a.localeCompare(b))
        .forEach((x, i) => console.log(`${i + 1}.${x}`));
}

sortArray(["John", "Bob", "Christina", "Ema"]);