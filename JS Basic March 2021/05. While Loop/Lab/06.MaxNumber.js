function maxNumber(input) {
    let index = 0;
    let command = input[index];

    let maxNumber = Number.MIN_SAFE_INTEGER;

    while (command !== "Stop") {
        let currentNum = parseInt(input[index++]);

        if (currentNum > maxNumber) {
            maxNumber = currentNum;
        }
        command = input[index];
    }
    console.log(maxNumber);
}
maxNumber(["100",
"99",
"80",
"70",
"Stop"]);
console.log(`-----------------`);
maxNumber(["-10",
"20",
"-30",
"Stop"]);
console.log(`-----------------`);
maxNumber(["45",
"-20",
"7",
"99",
"Stop"]);
console.log(`-----------------`);
maxNumber(["999",
"Stop"]);
console.log(`-----------------`);
maxNumber(["-1",
"-2",
"Stop"]);

