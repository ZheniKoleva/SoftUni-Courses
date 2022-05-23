function getSmallestNumbers(input) {
    const result = input.sort((a, b) => a - b)
        .slice(0, 2)
        .join(' ');

    console.log(result);
}

getSmallestNumbers([30, 15, 50, 5]);
getSmallestNumbers([3, 0, 10, 4, 7, 3]);