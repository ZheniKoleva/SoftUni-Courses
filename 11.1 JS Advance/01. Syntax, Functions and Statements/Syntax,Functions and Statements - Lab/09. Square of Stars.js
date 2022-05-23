function printSquare(size = 5){
    let symbol = '* ';

    for (let row = 0; row < size; row++) {
        console.log(symbol.repeat(size));            
    }
}

printSquare(1);
printSquare(2);
printSquare(5);
printSquare();