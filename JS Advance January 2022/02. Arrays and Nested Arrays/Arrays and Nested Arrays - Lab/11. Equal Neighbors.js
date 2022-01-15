function getEqualNeighbors(matrix) {
    let equalNeighbors = 0;
    debugger
    for (let row = 0; row < matrix.length; row++) {

        const isLastRow = row == matrix.length - 1;

        for (let col = 0; col < matrix[row].length; col++) {

            const isLastCol = col == matrix[row].length - 1;

            if (!isLastRow && !isLastCol
                && matrix[row][col] === matrix[row + 1][col]) {

                equalNeighbors++;
            }

            if (!isLastCol &&
                matrix[row][col] === matrix[row][col + 1]) {

                equalNeighbors++;
            }

            if (isLastCol && !isLastRow && matrix[row][col] === matrix[row + 1][col]) {

                equalNeighbors++;
            }
        }

    }

    return equalNeighbors;
}

console.log(getEqualNeighbors([
    ['2', '3', '4', '7', '0'],
    ['4', '0', '5', '3', '4'],
    ['2', '3', '5', '4', '2'],
    ['9', '8', '7', '5', '4']
]));

console.log(getEqualNeighbors([
    ['test', 'yes', 'yo', 'ho'],
    ['well', 'done', 'yo', '6'],
    ['not', 'done', 'yet', '5']
]));

console.log(getEqualNeighbors([
    [2, 2, 5, 7, 4],
    [4, 0, 5, 3, 4],
    [2, 5, 5, 4, 2]
]));