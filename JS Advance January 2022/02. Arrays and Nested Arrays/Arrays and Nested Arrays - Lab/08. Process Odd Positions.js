function getOddPositions(input) {
    return input.filter((x, i) => i % 2 == 1)
        .map(x => x * 2)
        .reverse()
        .join(' ');
}

console.log(getOddPositions([10, 15, 20, 25]));
console.log(getOddPositions([3, 0, 10, 4, 7, 3]));