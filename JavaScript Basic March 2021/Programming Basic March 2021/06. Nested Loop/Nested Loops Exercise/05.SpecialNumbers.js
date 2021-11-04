function specialNumbers(input) {
    let number = parseInt(input[0]);
    let result = "";

    for (let digit1 = 1; digit1 <= 9; digit1++) {
        for (let digit2 = 1; digit2 <= 9; digit2++) {
            for (let digit3 = 1; digit3 <= 9; digit3++) {
                for (let digit4 = 1; digit4 <= 9; digit4++) {

                    let isValid = (number % digit1 === 0 && number % digit2 === 0
                        && number % digit3 === 0 && number % digit4 === 0);

                    if (isValid) {
                        result += `${digit1}${digit2}${digit3}${digit4} `;
                    }
                }
            }
        }
    }

    console.log(result);
}
specialNumbers(["3"]);
specialNumbers(["16"]);
specialNumbers(["16"]);