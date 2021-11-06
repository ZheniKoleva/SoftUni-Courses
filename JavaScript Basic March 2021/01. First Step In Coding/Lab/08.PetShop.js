function petShop(input) {
    let dogsCount = Number(input[0]);
    let animalsCount = Number(input[1]);

    const priceForDogs = 2.50;
    const priceForAnimals = 4.00;

    let totalSum = (dogsCount * priceForDogs) + (animalsCount * priceForAnimals);
    console.log(`${totalSum} lv.`);    
}
petShop(["5", "4"]);

petShop(["13", "9"]);