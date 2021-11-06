function fruitOrVegetable(input) {
    let product = input[0];

    let isFruit = product === "banana" || product === "apple" || product === "kiwi"
                || product === "cherry" || product === "lemon" || product === "grapes";
    let isVegetable = product === "tomato" || product === "cucumber"
                      || product === "pepper" || product === "carrot";

    if (isFruit) {
        console.log("fruit");

    } else if (isVegetable) {
        console.log("vegetable");

    } else {
        console.log("unknown");
    }                
}
fruitOrVegetable(["banana"]);
fruitOrVegetable(["apple"]);
fruitOrVegetable(["tomato"]);
fruitOrVegetable(["water"]);