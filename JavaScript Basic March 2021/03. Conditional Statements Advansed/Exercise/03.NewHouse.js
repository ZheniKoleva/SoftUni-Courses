function newHouse(input) {
    let flower = input[0];
    let flowerCount = Number(input[1]);
    let budget = Number(input[2]);

    let price = 0.00;

    switch (flower) {
        case "Roses":
            price = 5.00;
            price *= flowerCount;
            if (flowerCount > 80) {
                price -= price * 0.10;
            }
            break;
        case "Dahlias":
            price = 3.80;
            price *= flowerCount;
            if (flowerCount > 90) {
                price -= price * 0.15;
            }
            break;
        case "Tulips":
            price = 2.80;
            price *= flowerCount;
            if (flowerCount > 80) {
                price -= price * 0.15;
            }
            break;
        case "Narcissus":
            price = 3.00;
            price *= flowerCount;
            if (flowerCount < 120) {
                price += price * 0.15;
            }
            break;
        case "Gladiolus":
            price = 2.50;
            price *= flowerCount;
            if (flowerCount < 80) {
                price += price * 0.20;
            }
            break;
    }
    let difference = Math.abs(budget - price);

    if (budget >= price) {
        console.log(`Hey, you have a great garden with ${flowerCount} ${flower} and ${difference.toFixed(2)} leva left.`);
    }else {
        console.log(`Not enough money, you need ${difference.toFixed(2)} leva more.`);
    }
}
newHouse(["Roses",
    "55",
    "250"]);

newHouse(["Tulips",
    "88",
    "260"]);

newHouse(["Narcissus",
    "119",
    "360"]);

