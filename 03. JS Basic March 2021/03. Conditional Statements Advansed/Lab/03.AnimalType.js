function animalType(input) {
    let animal = input[0];
    let output = null;

    switch (animal) {
        case "dog":
            output = "mammal"; break;
        case "crocodile":
        case "tortoise":
        case "snake":
            output = "reptile"; break;
        default:
            output = "unknown"; break;
    }
    console.log(output);
}
animalType(["dog"]);
animalType(["snake"]);
animalType(["cat"]);