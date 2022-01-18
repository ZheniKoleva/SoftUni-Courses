function moving(input) {
    let index = 0;
    let width = parseInt(input[index++]);
    let length = parseInt(input[index++]);
    let height = parseInt(input[index++]);

    let volume = width * length * height;
    let isNoSpace = false;
    let command = input[index];

    while (command !== "Done") {
        volume -= parseInt(input[index++]);
        if (volume <= 0) {
            isNoSpace = true;
            break;
        }
        command = input[index];
    }

    if (isNoSpace) {
        console.log(`No more free space! You need ${Math.abs(volume)} Cubic meters more.`);

    }else {
        console.log(`${volume} Cubic meters left.`);
    }
}
moving(["10", 
"10",
"2",
"20",
"20",
"20",
"20",
"122"]);
console.log(`-----------------`);
moving(["10",
"1",
"2",
"4",
"6",
"Done"]);

