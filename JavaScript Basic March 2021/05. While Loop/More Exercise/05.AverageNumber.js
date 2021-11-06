function averageNumber(input) {
    let numbers = parseInt(input[0]);
    let sum = 0;

    for (let index = 1; index <= numbers; index++) {
        sum += Number(input[index]);                
    }

    console.log(`${(sum / numbers).toFixed(2)}`);
}
averageNumber(["4", "3", "2", "4", "2"]);
averageNumber(["2", "6", "4"]);
averageNumber(["3", "82", "43", "22"]);
averageNumber(["4", "95", "23", "76", "23"]);