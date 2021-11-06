function factorial(input) {
    let number = parseInt(input[0]);
    let result = 1;

    for (let factor = 1; factor <= number; factor++) {
        result *= factor;
    }
    console.log(result);       
}
factorial(["4"]);
factorial(["8"]);