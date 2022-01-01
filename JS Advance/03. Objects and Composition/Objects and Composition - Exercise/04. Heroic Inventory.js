function heroicInventory(inputArray){
    const heroes = [];

    for (const heroData of inputArray) {
        let [name, level, items] = heroData.split(' / ');
        level = Number(level);
        items = items ? items.split(', ') : [];

        const currentHero = {name, level, items};
        heroes.push(currentHero)
    }

    const heroesAsJSON = JSON.stringify(heroes);
    console.log(heroesAsJSON);
}

heroicInventory([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
]);

heroicInventory(['Jake / 1000 / Gauss, HolidayGrenade']);