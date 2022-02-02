function carRegister(inputData) {
    const carBrands = new Map();

    inputData.forEach(x => {
        const [carBrand, carModel, count] = x.split(' | ');

        if (!carBrands.has(carBrand)) {
            carBrands.set(carBrand, new Map());
        }

        if (!carBrands.get(carBrand).has(carModel)) {
            carBrands.get(carBrand).set(carModel, 0);
        }

        const currentCount = carBrands.get(carBrand).get(carModel) + Number(count);
        carBrands.get(carBrand).set(carModel, currentCount);
    });

    carBrands.forEach((models, brand) => {
        console.log(brand);
        models.forEach((count, model) => {
            console.log(`###${model} -> ${count}`);
        })
    });
}

carRegister(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10'
]);