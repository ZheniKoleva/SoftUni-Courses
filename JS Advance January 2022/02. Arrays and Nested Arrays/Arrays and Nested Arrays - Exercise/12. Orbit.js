function orbitArray(inputArray){
    const [columns, rows, x, y] = inputArray;

    let matrix = new Array(rows); 

    for (let row = 0; row < rows; row++) {

        matrix[row] = new Array(columns);

        for (let col = 0; col < columns; col++) {
            const rowDifference = Math.abs(row - x);
            const columnDifference = Math.abs(col - y);

            matrix[row][col] = Math.max(rowDifference, columnDifference) + 1;            
        }        
    }

    matrix.forEach(row => console.log(row.join(' ')));
}

orbitArray([4, 4, 0, 0]);

 orbitArray([5, 5, 2, 2]);

orbitArray([3, 3, 2, 2]);