function printSquare(size = 5){
    let symbol = '*';
    const row = Array(size).fill(symbol);
    const matrix = Array(size).fill(row);

    matrix.forEach(row => console.log(row.join(' ')));   
}

printSquare(1);
printSquare(2);
printSquare(5);
printSquare(7);