function calculatePrice(product, amountInGrams, pricePerKg){
    const amountInKg = amountInGrams / 1000;
    const price =  amountInKg * pricePerKg;

    console.log(`I need $${price.toFixed(2)} to buy ${amountInKg.toFixed(2)} kilograms ${product}.`);
}

calculatePrice('orange', 2500, 1.80);
calculatePrice('apple', 1563, 2.35);

 