function isMagicalMatrix(matrix){
    const searchedSum = matrix[0].reduce((a, b) => a + b, 0);
    let isMagic = true;

    for (let row = 0; row < matrix.length; row++) {
        const rowSum = matrix[row].reduce((a, b) => a + b, 0);

        let columnSum = 0;

        for (let col = 0; col < matrix.length; col++) {
            columnSum += matrix[col][row];
        }

        if (rowSum !== searchedSum || columnSum !== searchedSum) {
            isMagic = false;
            break;
        }
    }

    return isMagic;
}

console.log(isMagicalMatrix([
    [4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]
]));

console.log(isMagicalMatrix([
    [11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]
]));

console.log(isMagicalMatrix([
    [1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]
]));