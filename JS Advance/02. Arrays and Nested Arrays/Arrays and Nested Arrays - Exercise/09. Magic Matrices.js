function isMatrixMagic(matrix){    
    let searchedSum = 0;

    for (let row = 0; row < matrix.length; row++) {  

        let currentRowSum = matrix[row].reduce((a, b) => a + b, 0);

        if (row === 0) {
            searchedSum = currentRowSum;
            continue;
        }

        if (searchedSum !== currentRowSum) {
            return false;
        }       
    }   

    for (let col = 0; col < matrix.length; col++) {

        let currentColSum = 0;

        for (let row = 0; row < matrix.length; row++) {
            currentColSum += matrix[row][col];
        }

        if (searchedSum !== currentColSum) {
            return false;
        }
    }    

    return true;
}

console.log(isMatrixMagic([
    [4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]
]));

console.log(isMatrixMagic([
    [11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]
]));

console.log(isMatrixMagic([
    [1, 0, 0],
    [0, 0, 1],
    [0, 1, 0] 
]));