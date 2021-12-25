function getGreatestDivisor(firstDigit, secondDigit){
    let biggerDigit = Math.max(firstDigit, secondDigit);
    
    let greatestDivisor = 1;

    for (let index = biggerDigit; index > 0; index--) {

        let isBothDivisible = firstDigit % index == 0 && secondDigit % index == 0;

        if (isBothDivisible && greatestDivisor < index) {
            greatestDivisor = index;
        }
    }

    console.log(greatestDivisor);
}

getGreatestDivisor(15, 5);
getGreatestDivisor(2154, 458);