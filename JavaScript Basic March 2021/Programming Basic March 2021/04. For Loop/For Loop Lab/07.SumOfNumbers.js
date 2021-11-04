function sumOfNumbers(input) {
    let numAsText = input[0];
    let sum = 0;

    for (let i = 0; i < numAsText.length; i++) {
        sum += Number(numAsText[i]);
    }
    console.log(`The sum of the digits is:${sum}`);
}
sumOfNumbers(["1234"]);
sumOfNumbers(["564891"]);