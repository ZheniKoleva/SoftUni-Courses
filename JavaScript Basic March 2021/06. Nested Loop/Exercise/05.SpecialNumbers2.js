function specialNumbers(input) {
    let number = parseInt(input[0]);
    let result = "";

    for (let digit = 1111; digit <= 9999; digit++) {
        let digitAsText = digit + "";
        let isValid = true;

        for (let index = 0; index < digitAsText.length; index++) {
            
            let currentDigit = parseInt(digitAsText[index]);
            if (number % currentDigit !== 0) {
                isValid = false;
                break;
            }            
        }

        if (isValid) {
            result += digit + " ";
        }
    }

    console.log(result);
}
specialNumbers(["3"]);
specialNumbers(["16"]);
specialNumbers(["16"]);