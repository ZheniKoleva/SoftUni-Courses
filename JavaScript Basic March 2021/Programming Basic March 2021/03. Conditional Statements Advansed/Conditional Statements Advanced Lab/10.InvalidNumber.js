function invalidNumber(input) {
    let number = parseInt(input[0]);

    let isValid = (number >= 100 && number <= 200) || number === 0;
    if (!isValid) {
        console.log("invalid");
    }
}
invalidNumber(["75"]);
invalidNumber(["150"]);
invalidNumber(["220"]);
invalidNumber(["199"]);
invalidNumber(["-1"]);
invalidNumber(["100"]);
invalidNumber(["200"]);
invalidNumber(["0"]);
