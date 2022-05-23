function cake(input) {
    let index = 0;
    let cakeSize = parseInt(input[index++]) * parseInt(input[index++]);

    let isEaten = false;
    let command = input[index];

    while (command !== "STOP") {
        cakeSize -= parseInt(command);

        if (cakeSize <= 0) {
            isEaten = true;
            break;
        }
        command = input[++index];
    }

    if (isEaten) {
        console.log(`No more cake left! You need ${Math.abs(cakeSize)} pieces more.`);

    }else {
        console.log(`${cakeSize} pieces are left.`)
    }
}
cake(["10", "10", "20", "20", "20", "20", "21"]);
cake(["10", "2", "2", "4", "6", "STOP"]);

