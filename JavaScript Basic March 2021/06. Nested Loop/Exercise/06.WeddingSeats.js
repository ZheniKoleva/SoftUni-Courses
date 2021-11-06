function weddingSeats(input) {
    let endSector = input.shift();
    let rowsCountStart = parseInt(input.shift());
    let seatsOddRow = parseInt(input.shift());

    let seatsEvenRow = seatsOddRow + 2;
    let seatsCount = 0;

    for (let sector = 'A'; sector <= endSector; sector++){
        
        if (sector !== 'A') {
            rowsCountStart++;
        }

        for (let row = 1; row <= rowsCountStart; row++) {
            
            if (row % 2 === 0) {

                for (let seat = 'a'; seat <= 'a' + seatsEvenRow; seat++) {
                    
                    console.log(`${sector}${row}${seat}`);
                    seatsCount++;

                }

            }else {

                for (let seat = 'a'; seat <= 'a' + seatsOddRow; seat++) {
                    
                    console.log(`${sector}${row}${seat}`);
                    seatsCount++;
                    
                }
            }
        }
       
    }

    console.log(seatsCount);

}
weddingSeats(["B", "3", "2"]);
weddingSeats(["C", "4", "2"]);


