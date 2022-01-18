function evenPowerOf2(input) {
    let power = parseInt(input[0]);

    for (let i = 0; i <= power; i += 2) {
        console.log(Math.pow(2, i));
    }
}
evenPowerOf2(["3"]);
console.log(`---------------`);
evenPowerOf2(["4"]);
console.log(`---------------`);
evenPowerOf2(["5"]);
console.log(`---------------`);
evenPowerOf2(["6"]);
console.log(`---------------`);
evenPowerOf2(["7"]);
