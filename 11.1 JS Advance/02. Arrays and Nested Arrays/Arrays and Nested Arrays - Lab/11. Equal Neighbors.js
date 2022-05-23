function getEqualNeighbors(matrix){    
    let equalNeigborsCount = 0;

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            
            let isLastRow = row === matrix.length - 1;
            let isLastCol = col === matrix[row].lenght - 1;

            if (!isLastRow 
                && matrix[row][col] === matrix[row + 1][col]) {

                equalNeigborsCount++;
            }

            if (!isLastCol &&
                matrix[row][col] === matrix[row][col + 1]) {

                equalNeigborsCount++;
            } 
            
            if (isLastCol && !isLastRow 
                && matrix[row][col] === matrix[row + 1][col]) {
                
                equalNeigborsCount++;
            }
        }       
    }

    return equalNeigborsCount;
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