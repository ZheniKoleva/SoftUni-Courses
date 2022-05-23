function spiralMatrix(rows, columns){    
    let startNumber = 1;

    let matrix = new Array(rows);

    for (let row = 0; row < matrix.length; row++) {
        matrix[row] = new Array(columns);         
    }

    for (let row = 0; row < matrix.length; row++) {        
        
        startNumber = goRight(matrix, row, row, matrix.length - row, startNumber);

        startNumber = goDown(matrix, matrix.length -1 - row, row + 1, matrix.length - 1 - row, startNumber);

        startNumber = goLeft(matrix, matrix.length - 1 - row, matrix.length - 2 - row, row, startNumber);

        startNumber = goUp(matrix, row,matrix.length - 2 - row, row + 1, startNumber);

    }

    function goRight(matrix, row, startCol, endCol, startNumber){
        for (let col = startCol; col < endCol; col++) {
           
            matrix[row][col] = startNumber++; 
        }

        return startNumber;
    }

    function goDown(matrix, col, startRow, endRow, startNumber){
        for (let row = startRow; row <= endRow; row++) {
           
            matrix[row][col] = startNumber++;                     
        }

        return startNumber;
    }

    function goLeft(matrix, row, startCol, endCol, startNumber){
        for (let col = startCol; col >= endCol; col--) {
           
            matrix[row][col] = startNumber++;            
        }

        return startNumber;
    }

    function goUp(matrix, col, startRow, endRow, startNumber){
        for (let row = startRow; row >= endRow; row--) {
           
            matrix[row][col] = startNumber++;            
        }

        return startNumber;
    }

    matrix.forEach(row => console.log(row.join(' ')));    
}

spiralMatrix(5, 5);
spiralMatrix(3, 3);