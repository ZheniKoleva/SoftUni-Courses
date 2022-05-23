function storeCatalogue(inputArray) {
    inputArray.sort((a, b) => a.localeCompare(b));

    const catalogue = {};

    inputArray.forEach(productData => {
        const firstLetter = productData[0];
        const [productName, price] = productData.split(' : ');

        if (!catalogue.hasOwnProperty(firstLetter)) {
            catalogue[firstLetter] = {};
        }

        catalogue[firstLetter][productName] = price;
    });

    for (const firstLetter in catalogue) {
        const sorted = Object.keys(catalogue[firstLetter])
            .sort((a, b) => a.localeCompare(b));

        console.log(firstLetter);
        sorted
            .forEach(productName =>
                console.log(`  ${productName}: ${catalogue[firstLetter][productName]}`));
    }
}

storeCatalogue(
    [
        'Appricot : 20.4',
        'Fridge : 1500',
        'TV : 1499',
        'Deodorant : 10',
        'Boiler : 300',
        'Apple : 1.25',
        'Anti-Bug Spray : 15',
        'T-Shirt : 10'
    ]
);

storeCatalogue(
    [
        'Banana : 2',
        'Rubic\'s Cube: 5',
        'Raspberry P : 4999',
        'Rolex : 100000',
        'Rollon : 10',
        'Rali Car : 2000000',
        'Pesho : 0.000001',
        'Barrel : 10'
    ]
);

