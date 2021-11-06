function numbersDivisibleBy9(input) {
    let startNum = parseInt(input[0]);
    let endNum = parseInt(input[1]);

    let sum = 0;
    let numbersDevided = "";

    for (let i = startNum; i <= endNum; i++) {
        if (i % 9 == 0) {
            sum += i;
            numbersDevided += i + '\n';
        }        
    }
    console.log(`The sum: ${sum}\n${numbersDevided}`);
}
numbersDivisibleBy9(["100", "200"]);