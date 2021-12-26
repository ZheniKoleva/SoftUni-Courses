function getBiggerHalf(inputArray){
    let sorted = inputArray
        .map(x => x)
        .sort((x, y) => x - y)
        .slice(-Math.ceil(inputArray.length / 2));
        
    return sorted;
}

console.log(getBiggerHalf([4, 7, 2, 5]));
console.log(getBiggerHalf([3, 19, 14, 7, 2, 19, 6]));