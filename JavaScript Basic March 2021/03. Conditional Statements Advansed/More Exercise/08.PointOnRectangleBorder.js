function pointOnRectangleBorder(input) {
    let x1 = parseInt(input[0]);
    let y1 = parseInt(input[1]);
    let x2 = parseInt(input[2]);
    let y2 = parseInt(input[3]);
    let x = parseInt(input[4]);
    let y = parseInt(input[5]);

    let isValidX = (x1 === x || x2 === x) && (y1 <= y && y2 >= y);
    let isValidY = (y1 === y || y2 === y) && (x1 <= x && x2 >= x)

    if (isValidX || isValidY) {
        console.log("Border");
    } else {
        console.log("Inside / Outside");
    }
}
pointOnRectangleBorder(["2", "-3", "12", "3", "8", "-1"]);

pointOnRectangleBorder(["2", "-3", "12", "3", "12", "-1"]);

pointOnRectangleBorder(["2", "-3", "12", "3", "2", "3"]);