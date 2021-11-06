function personalTiles(input) {
    let age = Number(input[0]);
    let gender = input[1];
    let output = null;

    if (age >= 16) {
        switch (gender) {
            case 'f': 
                output = "Ms."; break;
            case 'm':
                output = "Mr."; break;
        }

    } else {
        switch (gender) {
            case 'f': 
                output = "Miss"; break;
            case 'm':
                output = "Master"; break;
        }
    }
    console.log(output);
}
personalTiles(["12", "f"]);
personalTiles(["17", "m"]);
personalTiles(["25", "f"]);
personalTiles(["13.5", "m"]);