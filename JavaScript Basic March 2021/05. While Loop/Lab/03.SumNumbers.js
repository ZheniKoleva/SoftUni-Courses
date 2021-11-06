function sumNumbers(input) {
    let index = 0;
    let number = parseInt(input[index++]);
    let sum = 0;

    while (sum < number) {
        sum += parseInt(input[index++]);
    }
    console.log(sum);
}
sumNumbers(["100",
"10",
"20",
"30",
"40"]);
console.log(`-----------------`);
sumNumbers(["20",
"1",
"2",
"3",
"4",
"5",
"6"]);

