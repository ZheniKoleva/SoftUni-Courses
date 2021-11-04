function passwordGuess (input) {
    let password = input[0] === "s3cr3t!P@ssw0rd" ? console.log("Welcome") : console.log("Wrong password!");

}
passwordGuess(["qwerty"]);
passwordGuess(["s3cr3t!P@ssw0rd"]);
passwordGuess(["s3cr3t!p@ss"]);