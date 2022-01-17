function diagonalAttack(inputArray) {    
    let matrix = [];

    for (const row of inputArray) {
        let currentRow = row.split(' ').map(x => Number(x));

        matrix.push(currentRow);
    }

    let leftSum = 0;
    let rightSum = 0;

    for (let index = 0; index < matrix.length; index++) {
        leftSum += matrix[index][index];
        rightSum += matrix[index][matrix.length - 1 - index];
    }


    if (leftSum == rightSum) {
        for (let row = 0; row < matrix.length; row++) {
            for (let col = 0; col < matrix.length; col++) {
                if (row !== col && col !== matrix.length - 1 - row) {
                    matrix[row][col] = leftSum;
                }

            }
        }
    }

    matrix.forEach(row => console.log(row.join(' ')));
}

diagonalAttack([
    '5 3 12 3 1',
    '11 4 23 2 5',
    '101 12 3 21 10',
    '1 4 5 2 2',
    '5 22 33 11 1'
]);

diagonalAttack([
    '1 1 1',
    '1 1 1',
    '1 1 0'
]);