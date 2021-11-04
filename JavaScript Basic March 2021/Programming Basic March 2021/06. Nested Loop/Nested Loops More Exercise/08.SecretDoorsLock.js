function secretDoorLock(input) {
    let end100 = parseInt(input.shift());
    let end10 = parseInt(input.shift());
    let end1 = parseInt(input.shift());

    let result = "";

    for (let first = 2; first <= end100; first += 2) {
        for (let second = 2; second <= end10; second++) {
           for (let third = 2; third <= end1; third += 2) {
               
                let isSecondPrime = true;
                let limit = Math.trunc(Math.sqrt(second));
                for (let index = 2; index <= limit; index++) {
                    
                    if (second % index == 0) {
                        isSecondPrime = false;
                    }                    
                }

                if (isSecondPrime) {
                    console.log(`${first} ${second} ${third}\n`);
                } 

           }            
        }        
    }

    console.log(result);
}
secretDoorLock(["3", "5", "5"]);
secretDoorLock(["8", "2", "8"]);
