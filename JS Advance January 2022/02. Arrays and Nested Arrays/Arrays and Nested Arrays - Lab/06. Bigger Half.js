function getBiggerHalf(input) {
    const sliceIndex = Math.floor(input.length / 2);

    const result = input
        .sort((a, b) => a - b)
        .slice(sliceIndex);

    return result;
}

console.log(getBiggerHalf([4, 7, 2, 5]));
console.log(getBiggerHalf([3, 19, 14, 7, 2, 19, 6]));

