function numberInRange(input) {
    let number = parseInt(input[0]);

    let isValid = (number >= -100 && number <= 100) && number != 0;
    let output = isValid ? "Yes" : "No";
    console.log(output);
}
numberInRange(["-25"]);
numberInRange(["0"]);
numberInRange(["25"]);