function backToThePast(input) {
    let moneyInherited = Number(input[0]);
    let endYear = parseInt(input[1]);

    let ageOfIvan = 18;
    let startYear = 1800;

    for (let currentYear = startYear; currentYear <= endYear; currentYear++) {
        
        if (currentYear % 2 == 0) {
            moneyInherited -= 12000;

        } else {
            moneyInherited -= 12000 + ageOfIvan * 50;
        }        
        ageOfIvan++;
    }

    if (moneyInherited >= 0) {
        console.log(`Yes! He will live a carefree life and will have ${moneyInherited.toFixed(2)} dollars left.`);

    } else {
        console.log(`He will need ${Math.abs(moneyInherited).toFixed(2)} dollars to survive.`);
    }
}
backToThePast(["50000", "1802"]);
backToThePast(["100000.15", "1808"]);