function heroicInventory(inputData) {
    const heroesList = [];

    inputData.forEach(heroData => {
        const [heroName, heroLevel, heroItems] = heroData.split(' / ');

        const hero = {
            name: heroName,
            level: Number(heroLevel),
            items: heroItems ? heroItems.split(', ') : [],
        };

        heroesList.push(hero);
    });

    console.log(JSON.stringify(heroesList));
}

heroicInventory(
    [
        'Isacc / 25 / Apple, GravityGun',
        'Derek / 12 / BarrelVest, DestructionSword',
        'Hes / 1 / Desolator, Sentinel, Antara'
    ]
);


heroicInventory(['Jake / 1000 / Gauss, HolidayGrenade']);