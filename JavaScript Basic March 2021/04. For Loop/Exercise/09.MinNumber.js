function minNumber(input) {
    let numberCount = Number(input[0]);

    let minNumber = Number.MAX_SAFE_INTEGER;

    for (let index = 1; index <= numberCount; index++) {
        
        if (input[index] < minNumber) {
            minNumber = Number(input[index]);
        }        
    }
    console.log(minNumber);    
}
minNumber(["2", "100", "99"]);
minNumber(["3", "-10", "20", "-30"]);
minNumber(["4", "45", "-20", "7", "99"]);
minNumber(["1", "999"]);
minNumber(["2", "-1", "-2"]);