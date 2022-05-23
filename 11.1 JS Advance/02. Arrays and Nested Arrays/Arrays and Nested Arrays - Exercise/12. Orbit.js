function orbit(inputArray){
    const columns = inputArray[0];
    const rows = inputArray[1];
    const startRow = inputArray[2];
    const startCol = inputArray[3];

    let matrix = [];    

    for (let row = 0; row < rows; row++) {

        matrix[row] = [];

        for (let col = 0; col < columns; col++) {
             
            let rowDifference = Math.abs(row - startRow);
            let columnDifference = Math.abs(col - startCol);

            let numberToFill = Math.max(rowDifference, columnDifference) + 1;
            
            matrix[row][col] = numberToFill;
        }                
    }

    matrix.forEach(row => console.log(row.join(' ')));    
}

orbit([4, 4, 0, 0]);

orbit([5, 5, 2, 2]);

orbit([3, 3, 2, 2]);