function ticTacToe(playersMoves) {
    let field = [
        [false, false, false],
        [false, false, false],
        [false, false, false]
    ];

    let playerOne = 'X';
    let playerTwo = 'O';
    let isPlayerOneTurn = true;     

    for (let index = 0; index < playersMoves.length; index++) {
          
        let currentCoordinates = playersMoves[index].split(' ').map(x => Number(x));
        let playerRow = currentCoordinates[0];
        let playerCol = currentCoordinates[1];      

        if (field[playerRow][playerCol] !== false) {
            console.log('This place is already taken. Please choose another!');
            continue;
        }     

        let symbol = isPlayerOneTurn ? playerOne : playerTwo;
        field[playerRow][playerCol] = symbol;
 
        let hasWon = ifRowWin(field, playerRow, symbol)
            || ifColumnWin(field, playerCol, symbol)
            || ifLeftDiagonalWin(field, playerRow, playerCol, symbol)
            || ifRightDiagonalWin(field, playerRow, playerCol, symbol);

        if (hasWon) {
            console.log(`Player ${symbol} wins!`);
            break;
        }

        if (AllCellsTaken(field)) {
            console.log(`The game ended! Nobody wins :(`);
            break;
        }

        isPlayerOneTurn = !isPlayerOneTurn;
    }    

    field.forEach(row => console.log(row.join('\t')));

    function ifRowWin(matrix, row, symbol) {
        return matrix[row].every(x => x === symbol); 
    }

    function ifColumnWin(matrix, col, symbol) {
        for (let row = 0; row < matrix.length; row++) {

            if (matrix[row][col] !== symbol) {
                return false;
            }
        }

        return true;
    }

    function ifLeftDiagonalWin(matrix, row, col, symbol) {

        if (row !== col) {
            return false;
        }

        for (let row = 0; row < matrix.length; row++) {
            if (matrix[row][row] !== symbol) {
                return false;
            }            
        }

        return true;
    }

    function ifRightDiagonalWin(matrix, row, col, symbol) {
        if (col !== matrix.length - 1 - row) {
            return false;
        }
        
        for (let row = 0; row < matrix.length; row++) {

            if (matrix[row][matrix.length - 1 - row] !== symbol) {
                return false;
            }
        }

        return true;
    }

    function AllCellsTaken(matrix) {
        return matrix.every(row => row.every(x => x !== false));
    }

}

ticTacToe(["0 1",
    "0 0",
    "0 2",
    "2 0",
    "1 0",
    "1 1",
    "1 2",
    "2 2",
    "2 1",
    "0 0"]
);

ticTacToe(["0 0",
    "0 0",
    "1 1",
    "0 1",
    "1 2",
    "0 2",
    "2 2",
    "1 2",
    "2 2",
    "2 1"]
);

ticTacToe(["0 1",
    "0 0",
    "0 2",
    "2 0",
    "1 0",
    "1 2",
    "1 1",
    "2 1",
    "2 2",
    "0 0"]
);

