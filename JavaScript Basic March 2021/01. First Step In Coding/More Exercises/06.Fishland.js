function fishLand(input) {
    let mackerelPrice = Number(input[0]);
    let toyPrice = Number(input[1]);
    let bonitoAmount = Number(input[2]);
    let horseMackerelAmount = Number(input[3]);
    let musselsAmount = parseInt(input[4]);

    let bonitoPrice = mackerelPrice * 1.60;
    let horseMackerelPrice = toyPrice * 1.80;
    const musselsPrice = 7.50;

    let totalSum = (bonitoAmount * bonitoPrice) + (horseMackerelAmount * horseMackerelPrice) +
    (musselsAmount * musselsPrice);
    console.log(totalSum.toFixed(2));
}
fishLand(["6.90", "4.20", "1.5", "2.5", "1"]);
fishLand(["5.55", "3.57", "4.3", "3.6", "7"]);
fishLand(["7.79", "5.35", "9.3", "0", "0"]);