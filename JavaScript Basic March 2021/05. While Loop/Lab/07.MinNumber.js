function minNumber(input) {
    let index = 0;
    let command = input[index];

    let minNumber = Number.MAX_SAFE_INTEGER;

    while (command !== "Stop") {
        let currentNum = parseInt(input[index++]);

        if (currentNum < minNumber) {
            minNumber = currentNum;
        }
        command = input[index];
    }
    console.log(minNumber);
}
minNumber(["100",
"99",
"80",
"70",
"Stop"]);
console.log(`-----------------`);
minNumber(["-10",
"20",
"-30",
"Stop"]);
console.log(`-----------------`);
minNumber(["45",
"-20",
"7",
"99",
"Stop"]);
console.log(`-----------------`);
minNumber(["999",
"Stop"]);
console.log(`-----------------`);
minNumber(["-1",
"-2",
"Stop"]);

