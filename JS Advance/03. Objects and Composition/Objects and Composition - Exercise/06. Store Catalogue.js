function storeCatalogue(inputArray){
    const catalogue = {};

    inputArray.forEach(data => {
        let [productName, productPrice] = data.split(' : ');
        productPrice = Number(productPrice);
 
        let firstLetter = productName[0];
        if (!catalogue.hasOwnProperty(firstLetter)) {
            catalogue[firstLetter] = {};
        }

        catalogue[firstLetter][productName] = productPrice;
    });    

    const orderedKeyLetters = Object.keys(catalogue).sort((a,b) => a.localeCompare(b));

    for (const letter of orderedKeyLetters) {
        const orderedProducts = Object.entries(catalogue[letter]).sort((a,b) => a[0].localeCompare(b[0]))

        console.log(letter);
        orderedProducts.forEach((product)=> console.log(`  ${product[0]}: ${product[1]}`));
    }
}

storeCatalogue([
    'Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10'
]);

storeCatalogue([
    'Banana : 2',
    'Rubic\'s Cube : 5',
    'Raspberry P : 4999',
    'Rolex : 100000',
    'Rollon : 10',
    'Rali Car : 2000000',
    'Pesho : 0.000001',
    'Barrel : 10'
]);

