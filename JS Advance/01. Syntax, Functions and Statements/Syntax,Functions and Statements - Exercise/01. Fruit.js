function getPrice(product, amountInGrams, pricePerKg){
    let amountInKg = amountInGrams / 1000;
    let price =  amountInKg* pricePerKg;

    console.log(`I need $${price.toFixed(2)} to buy ${amountInKg.toFixed(2)} kilograms ${product}.`);
}

getPrice('orange', 2500, 1.80);
getPrice('apple', 1563, 2.35);