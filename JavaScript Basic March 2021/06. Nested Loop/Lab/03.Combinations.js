function combinations(input) {
    let number = parseInt(input[0]);

    let combinationsCount = 0;

    for (let x1 = 0; x1 <= number; x1++) {
        for (let x2 = 0; x2 <= number; x2++) {
            for (let x3 = 0; x3 <= number; x3++) {
                
                let isValid = (x1 + x2 + x3) === number;
                if (isValid) {
                    combinationsCount++;
                }                
            }            
        }        
    }

    console.log(combinationsCount);
}
combinations(["25"]);
combinations(["20"]);
combinations(["5"]);