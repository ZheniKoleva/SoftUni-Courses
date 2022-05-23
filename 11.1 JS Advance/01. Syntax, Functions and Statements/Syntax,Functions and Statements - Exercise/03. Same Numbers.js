function sameNumber(number){
    let numberAsArray = number.toString().split('');
    
    let areSame = numberAsArray.every(x => x === numberAsArray[0]);

    let sumOfDigits = numberAsArray.map(x => Number(x)).reduce((a,b) => a + b, 0);

    console.log(areSame);
    console.log(sumOfDigits);
}

sameNumber(2222222);
sameNumber(1234);