function bonusScore(input) {
    let number = parseInt(input[0]);
    let bonus = 0.00;

    if (number <= 100) {
        bonus += 5;
    } else if (number <= 1000) {
        bonus = number * 0.20;
    } else {
        bonus = number * 0.10;
    }

    if (number % 2 == 0) {
        bonus += 1;
    } else if (number % 10 == 5) {
        bonus += 2;
    }

    console.log(`${bonus}\n${number + bonus}`);
}
bonusScore(["20"]);
bonusScore(["175"]);
bonusScore(["2703"]);
bonusScore(["15875"]);