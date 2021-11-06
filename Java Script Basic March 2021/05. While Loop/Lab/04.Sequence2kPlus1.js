function sequense2KPlus1(input) {
    let number = parseInt(input[0]);
    let k = 1;

    while (k <= number) {
        console.log(k);
        k = k * 2 + 1;
    }
}
sequense2KPlus1(["3"]);
console.log(`-----------------`);
sequense2KPlus1(["8"]);
console.log(`-----------------`);
sequense2KPlus1(["17"]);
console.log(`-----------------`);
sequense2KPlus1(["31"]);