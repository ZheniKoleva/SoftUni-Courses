function solution() {
    const ingredients = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0,
    };

    const recipes = {
        apple: { carbohydrate: 1, flavour: 2 },
        lemonade: { carbohydrate: 10, flavour: 20 },
        burger: { carbohydrate: 5, fat: 7, flavour: 3 },
        eggs: { protein: 5, fat: 1, flavour: 1 },
        turkey: { protein: 10, carbohydrate: 10, fat: 10, flavour: 10 },
    };

    const orders = function (input) {
        const [command, dishOrProduct, quantity] = input.split(' ');

        const operations = {
            prepare: () => prepare(dishOrProduct, Number(quantity)),
            restock: () => restock(dishOrProduct, Number(quantity)),
            report: () => report(),
        }
      
        return operations[command]();
    };

    return orders;

    function prepare(dish, quantity) {
        const ingredientsNeeded = recipes[dish];
        const ingredientsKeys = Object.keys(ingredientsNeeded);
        const isEnough = ingredientsKeys
            .every(key => ingredients[key] >= (ingredientsNeeded[key] * quantity));

        let result = '';

        if (isEnough) {
            ingredientsKeys.forEach(key => {
                ingredients[key] -= (ingredientsNeeded[key] * quantity);

                result = 'Success';
            });

        } else {
            const missingIgredient = ingredientsKeys
                .find(key => ingredients[key] < (ingredientsNeeded[key] * quantity))

            result = `Error: not enough ${missingIgredient} in stock`;
        }

        return result;
    }

    function restock(ingredient, quantity){
        ingredients[ingredient] += quantity;

        return 'Success';
    }

    function report() {
        const result = Object.entries(ingredients)
            .map(([key, value]) => `${key}=${value}`)
            .join(' ');

        return result;
    }
}

let manager = solution(); 
console.log(manager("restock flavour 50")); // Success 
console.log(manager("prepare lemonade 4")); // Error: not enough carbohydrate in stock 
console.log(manager("restock carbohydrate 10")); // Success
console.log(manager("restock flavour 10")); // Success 
console.log(manager("prepare apple 1")); // Success 
console.log(manager("restock fat 10")); // Success
console.log(manager("prepare burger 1")); // Success
console.log(manager("report")); // protein=0 carbohydrate=4 fat=3 flavour=55

console.log('===================');
let manager2 = solution (); 
console.log(manager2("prepare turkey 1")); // Error: not enough protein in stock 
console.log(manager2("restock protein 10")); // Success
console.log(manager2("prepare turkey 1")); // Error: not enough carbohydrate in stock 
console.log(manager2("restock carbohydrate 10")); // Success 
console.log(manager2("prepare turkey 1")); // Error: not enough fat in stock 
console.log(manager2("restock fat 10")); // Success
console.log(manager2("prepare turkey 1")); //Error: not enough flavour in stock
console.log(manager2("restock flavour 10")); // Success
console.log(manager2("prepare turkey 1")); // Success
console.log(manager2("report")); //protein=0 carbohydrate=0 fat=0 flavour=0

