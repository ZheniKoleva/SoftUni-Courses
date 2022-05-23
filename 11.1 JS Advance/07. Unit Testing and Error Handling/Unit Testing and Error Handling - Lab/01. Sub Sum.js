function elementsSum(array, startIndx, endIndx){
    if (!Array.isArray(array) || array.some(x => !Number(x))) {
        return NaN;
    }

    const start = startIndx < 0 ? 0 : startIndx;
    const end = endIndx >= array.length ? array.length - 1 : endIndx;

    return array.slice(start, end + 1).reduce((a, b) => a + b, 0);
}

console.log(elementsSum([10, 20, 30, 40, 50, 60], 3, 300));
console.log(elementsSum([1.1, 2.2, 3.3, 4.4, 5.5], -3, 1));
console.log(elementsSum([10, 'twenty', 30, 40], 0, 2));
console.log(elementsSum([], 1, 2));
console.log(elementsSum('text', 0, 2));

