function depositCalculator(input) {
    let depositedSum = Number(input[0]);
    let term = Number(input[1]);
    let interest = Number(input[2]);

    let sumPerYear = depositedSum * interest / 100;
    let sumPerMonth = sumPerYear / 12;
    depositedSum += sumPerMonth * term;

    console.log(depositedSum);
}
depositCalculator(["200", "3", "5.7"]);
depositCalculator(["2350", "6", "7"]);