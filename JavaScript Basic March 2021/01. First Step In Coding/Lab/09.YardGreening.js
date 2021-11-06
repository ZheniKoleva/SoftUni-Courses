function yardGreening(input) {
    let areaToGreen = Number(input[0]);
    const pricePerSqMeter = 7.61;

    let totalPrice = areaToGreen * pricePerSqMeter;
    let discount = totalPrice * 0.18;
    totalPrice -= discount;

    console.log(`The final price is: ${totalPrice} lv.`);
    console.log(`The discount is: ${discount} lv.`);    
}
yardGreening(["550"]);

yardGreening(["150"]);
