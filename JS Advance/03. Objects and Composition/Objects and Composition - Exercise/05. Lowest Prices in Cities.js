function lowestPrices(inputArray){  
    const products = {};

    for (const data of inputArray) {
        let [productTown, productName, productPrice] = data.split(' | ');
        productPrice = Number(productPrice);

        if (!products.hasOwnProperty(productName)) {
            products[productName] = {};
        }

        products[productName][productTown] = productPrice;
    }    
  
   for (const item in products) {
        const ordered = Object.entries(products[item]).sort((a,b) => a[1] - b[1]);

       console.log(`${item} -> ${ordered[0][1]} (${ordered[0][0]})`)
   }

}

lowestPrices([
    'Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10'
]);