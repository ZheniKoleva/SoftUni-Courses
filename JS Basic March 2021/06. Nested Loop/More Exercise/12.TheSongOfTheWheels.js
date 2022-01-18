function songOfWheel(input) {
    let controlValue = parseInt(input[0]);

    let result = "";
    let counter = 0;
    let forthPassword = "";
    let isFound = false;
    let hasForthPassword = false;

    for (let a = 1; a <= 9; a++) {
        for (let b = 1; b <= 9; b++) {
            for (let c = 1; c <= 9; c++) {
                for (let d = 1; d <= 9; d++) {

                    let isValid = (a * b) + (c * d) === controlValue;
                    let isValidNums = (a < b) && (c > d);

                    if (isValid && isValidNums) {
                        result += (`${a}${b}${c}${d} `);
                        counter++;
                        isFound = true;

                        if (counter == 4) {
                            hasForthPassword = true;
                            forthPassword = (`${a}${b}${c}${d}`);
                        }

                    }
                }

            }

        }

    }

    if (isFound) {
        console.log(result);
        console.log(hasForthPassword ? `Password: ${forthPassword}` : "No!");

    } else {
        console.log("No!");
    }
}
songOfWheel(["11"]);
songOfWheel(["139"]);
songOfWheel(["110"]);
songOfWheel(["55"]);