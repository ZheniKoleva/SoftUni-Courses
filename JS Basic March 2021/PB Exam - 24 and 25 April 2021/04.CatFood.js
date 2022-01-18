function catFood(input) {
    let catCounts = parseInt(input[0]);

    let group1 = 0;
    let group2 = 0;
    let group3 = 0;
    let foodEatenInGrams = 0.0;
    let foodPricePerKg = 12.45;

    for (let index = 1; index <= catCounts; index++) {

        let currentFoodEaten = Number(input[index]);
        foodEatenInGrams += currentFoodEaten;

        if (currentFoodEaten < 200) {
            group1++;

        } else if (currentFoodEaten < 300) {
            group2++;

        } else if (currentFoodEaten < 400) {
            group3++;
        }

    }

    console.log(`Group 1: ${group1} cats.\n`
        + `Group 2: ${group2} cats.\n`
        + `Group 3: ${group3} cats.`);

    let foodPricePerDay = (foodEatenInGrams / 1000) * foodPricePerKg;
    console.log(`Price for food per day: ${foodPricePerDay.toFixed(2)} lv.`);
}
catFood(["6",
"102",
"236",
"123",
"399",
"342", 
"222"]);

catFood(["10",
"256",
"348",
"198",
"322",
"186",
"294",
"321",
"100",
"200",
"300"]);

catFood(["7",
"100",
"200",
"342",
"300",
"234",
"123",
"212"]);


