function primePairs(input) {
    let startPair1 = parseInt(input.shift());
    let startPair2 = parseInt(input.shift());
    let diffPair1 = parseInt(input.shift());
    let diffPair2 = parseInt(input.shift());

    let endPair1 = startPair1 + diffPair1;
    let endPair2 = startPair2 + diffPair2;

    for (let pair1 = startPair1; pair1 <= endPair1; pair1++) {
        for (let pair2 = startPair2; pair2 <= endPair2; pair2++) {
            
            if (pair1 % 2 == 0 || pair2 % 2 == 0) {
                continue;
            }
            
            let isPair1Prime = true;
            let limit1 = Math.trunc(Math.sqrt(pair1));
            for (let index = 3; index <= limit1; index++) {
                
                if (pair1 % index == 0) {
                    isPair1Prime = false;
                }
                
            }

            let isPair2Prime = true;
            let limit2 = Math.trunc(Math.sqrt(pair2));
            for (let index = 3; index <= limit2; index++) {
                
                if (pair2 % index == 0) {
                    isPair1Prime = false;
                }
                
            }

            if (isPair1Prime && isPair2Prime) {
                console.log(`${pair1}${pair2}`)
            }
        }
        
    }
    
}
primePairs(["10", "20", "5", "5"]);
primePairs(["10", "30", "9", "6"]);
