function getLowestPriceByTown(inputArray){
    const products = {};

    inputArray.forEach(productData => {
        const [productTown, productName, productPrice] = productData.split(' | ');

        if (!products.hasOwnProperty(productName)) {
            products[productName] = {};            
        }

        products[productName][productTown] = Number(productPrice);
    });
  
    for (const productName in products) {
        const sorted = Object.keys(products[productName])
            .sort((a, b) => products[productName][a] - products[productName][b]);

        console.log(`${productName} -> ${products[productName][sorted[0]]} (${sorted[0]})`);
    }

}

getLowestPriceByTown(
    [
        'Sample Town | Sample Product | 1000',
        'Sample Town | Orange | 2',
        'Sample Town | Peach | 1',
        'Sofia | Orange | 3',
        'Sofia | Peach | 2',
        'New York | Sample Product | 1000.1',
        'New York | Burger | 10'
    ]
);