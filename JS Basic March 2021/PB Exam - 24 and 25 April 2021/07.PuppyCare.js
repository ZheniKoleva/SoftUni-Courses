function puppyCare(input) {
    let index = 0;
    let boughtFood = Number(input[index++]) * 1000;
    let command = input[index++];

    let sum = 0;
    
    while (command !== "Adopted") {
        sum += Number(command);

        command = input[index++];
    }

    if (boughtFood >= sum) {
        console.log(`Food is enough! Leftovers: ${boughtFood - sum} grams.`);

    } else {
        console.log(`Food is not enough. You need ${sum - boughtFood} grams more.`);
    }
}
  puppyCare(["4", "130", "345", "400", "180", "230", "120", "Adopted"]);