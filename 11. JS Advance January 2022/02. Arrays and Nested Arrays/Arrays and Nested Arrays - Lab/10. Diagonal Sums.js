function getDiagonalsSum(matrix) {
    let leftDiagonal = 0;
    let rightDiagonal = 0;
    
    for (let row = 0; row < matrix.length; row++) {
        leftDiagonal += matrix[row][row]
        rightDiagonal += matrix[row][matrix.length - 1 - row];
    }
    
    console.log(leftDiagonal, rightDiagonal);
}

getDiagonalsSum([
    [20, 40],
    [10, 60]
]);

getDiagonalsSum([
    [3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89]
]);