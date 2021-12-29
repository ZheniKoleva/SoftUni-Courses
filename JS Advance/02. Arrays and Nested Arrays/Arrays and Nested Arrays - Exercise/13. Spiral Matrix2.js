function spiralMatrix(rows, columns){ 
    let matrix = new Array(rows);

    for (let row = 0; row < matrix.length; row++) {
        matrix[row] = new Array(columns);         
    }

    let startRow = 0;
    let endRow = rows - 1;
    let startCol = 0;
    let endCol = columns - 1;
    let startNumber = 1;

    while (startRow <= endRow && startCol <= endCol) {
        
        for (let col = startCol; col <= endCol; col++) {
            matrix[startRow][col] = startNumber++;
        }

        startRow++;

        for (let row = startRow; row <= endRow; row++) {
            matrix[row][endCol] = startNumber++;             
        }

        endCol--;

        for (let col = endCol; col >= startCol; col--) {
            matrix[endRow][col] = startNumber++;
        }

        endRow--;

        for (let row = endRow; row >= startRow; row--) {
            matrix[row][startCol] = startNumber++;
        }
            
        startCol++;
    }

    matrix.forEach(row => console.log(row.join(' ')));    
}

spiralMatrix(5, 5);
spiralMatrix(3, 3);