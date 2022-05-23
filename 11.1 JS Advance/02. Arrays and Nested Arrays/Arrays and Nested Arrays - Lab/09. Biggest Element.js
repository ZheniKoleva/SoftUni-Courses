function getBiggestElement(matrix){    
    let flatted = matrix
        .flat()
        .sort((a, b) => b - a);

    return flatted[0];
}

console.log(getBiggestElement([
    [20, 50, 10], 
    [8, 33, 145]
]));

console.log(getBiggestElement([
    [3, 5, 7, 12],
    [-1, 4, 33, 2],
    [8, 3, 0, 4]
]));