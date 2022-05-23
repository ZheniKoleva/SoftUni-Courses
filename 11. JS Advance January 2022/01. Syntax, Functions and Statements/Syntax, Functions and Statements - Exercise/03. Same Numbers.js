function sameNumbers(number){
    const numAsString = number.toString().split('');
    const isEquals = numAsString.every(x => x === numAsString[0]);
    const digitsSum = numAsString.reduce((a, b) => a + Number(b), 0);

    console.log(isEquals);
    console.log(digitsSum);
}

sameNumbers(2222222);
sameNumbers(1234);