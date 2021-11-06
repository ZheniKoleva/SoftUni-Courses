function excellentResult(input) {
    let isExcellent = input[0] >= 5.50;
    if (isExcellent) {
        console.log("Excellent!");
    }
}
excellentResult(["6"]);
excellentResult(["5"]);
excellentResult(["5.50"]);
excellentResult(["5.49"]);