function numberPyramid(input) {
    let limit = parseInt(input[0]);

    let isLimit = false;
    let number = 1;
    for (let row = 1; row <= limit; row++) {
        let result = "";
        for (let column = 1; column <= row; column++) {
            result += `${number} `;
            number++;

            if (number > limit) {
               isLimit = true;
                break; 
            }
        }
        console.log(`${result} `)
        if (isLimit) {
            break;
        }        
    }
}
numberPyramid(["1"]);
numberPyramid(["2"]);
/*numberPyramid(["7"]);
numberPyramid(["12"]);
numberPyramid(["15"]);*/