function fruitMarket(input) {
    let strawberryPrice = Number(input[0]);
    let bannanasAmount = Number(input[1]);
    let orangesAmount = Number(input[2]);
    let raspberriesAmount = Number(input[3]);
    let strawberriesAmount = Number(input[4]);

    let raspberryPrice = strawberryPrice / 2;
    let orangePrice = raspberryPrice * 0.60;
    let bannanaPrice = raspberryPrice * 0.20;

    let strawberrySum = strawberryPrice * strawberriesAmount;
    let bannanaSum = bannanaPrice * bannanasAmount;
    let orangeSum = orangePrice * orangesAmount;
    let raspberrySum = raspberryPrice * raspberriesAmount;

    let totalSum = strawberrySum + bannanaSum + orangeSum + raspberrySum;
    console.log(totalSum);
}
fruitMarket(["48", "10", "3.3", "6.5", "1.7"]);
fruitMarket(["63.5", "3.57", "6.35", "8.15", "2.5"]);