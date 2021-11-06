function sumPrimesNonPrimes(input) {
    let command = input.shift();

    let sumPrimes = 0;
    let sumNonPrimes = 0;

    while (command !== "stop") {
        let currentNumber = parseInt(command);

        if (currentNumber < 0) {
            console.log("Number is negative.")

        }else if (currentNumber === 2) {
            sumPrimes += currentNumber;

        }else if (currentNumber === 1 || currentNumber % 2 === 0){
            sumNonPrimes += currentNumber;

        }else {
            let isPrime = true;
            for (let index = 3; index <= Math.sqrt(currentNumber); index += 2) {
                if (currentNumber % index === 0) {
                    isPrime = false;
                    break;
                }                
            }

            if (isPrime) {
                sumPrimes += currentNumber;

            } else {
                sumNonPrimes += currentNumber;
            }
        }
        command = input.shift();
    }

    console.log(`Sum of all prime numbers is: ${sumPrimes}\n`
    + `Sum of all non prime numbers is: ${sumNonPrimes}`);
}
sumPrimesNonPrimes(["3",
"9",
"0",
"7",
"19",
"4",
"stop"]);

sumPrimesNonPrimes(["30",
"83",
"33",
"-1",
"20",
"stop"]);

sumPrimesNonPrimes(["0",
"-9",
"0",
"stop"]);


