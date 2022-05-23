function createJuice(inputData) {
    const products = new Map();
    const juices = new Map();

    inputData.forEach(x => {
        const [product, amount] = x.split(' => ');

        if (!products.has(product)) {
            products.set(product, 0);
        }

        let currentAmount = products.get(product) + Number(amount);
 
        if (currentAmount >= 1000) {
            if (!juices.has(product)) {
                juices.set(product, 0);
            }

            const currentBottles = juices.get(product) + Math.floor(currentAmount / 1000);
            juices.set(product, currentBottles);
            currentAmount %= 1000;
        }       

        products.set(product, currentAmount);
    });
  
    const result = [...juices.keys()]
        .map(k => `${k} => ${juices.get(k)}`)
        .join('\n');

    console.log(result);
}

createJuice(['Orange => 2000',
    'Peach => 1432',
    'Banana => 450',
    'Peach => 600',
    'Strawberry => 549'
]);

createJuice(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789'
]);