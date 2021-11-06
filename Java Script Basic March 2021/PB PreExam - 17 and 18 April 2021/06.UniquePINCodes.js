function uniquePinCode(input) {
    let endFirst = parseInt(input.shift());
    let endSecond = parseInt(input.shift());
    let endThird = parseInt(input.shift());

    for (let first = 2; first <= endFirst; first += 2) {
        for (let second = 2; second <= endSecond; second++) {
            for (let third = 2; third <= endThird; third += 2) {

                let isSecondPrime = true;
                let limit = Math.trunc(Math.sqrt(second))
                for (let index = 2; index <= limit; index++) {

                    if (second % index == 0) {
                        isSecondPrime = false;
                    }
                }

                if (isSecondPrime) {
                    console.log(`${first} ${second} ${third}`)
                }

            }
        }
    }
}
uniquePinCode(["3",
"5",
"5"]);

uniquePinCode(["8",
"2",
"8"]);

