function getDiagonalSum(matrix){    
    let leftDiagonal = 0;
    let rightDiagonal = 0;

    for (let index = 0; index < matrix.length; index++) {

       leftDiagonal += matrix[index][index];
       rightDiagonal += matrix[index][matrix.length - 1 - index];
    }

    console.log(leftDiagonal, rightDiagonal);    
}

getDiagonalSum([
    [20, 40],
    [10, 60]   
]);

getDiagonalSum([
    [3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89]
]);