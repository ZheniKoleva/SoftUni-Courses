function triangleArea(input) {
    let side = Number(input[0]);
    let height = Number(input[1]);

    let area = (side * height) / 2;
    console.log(area.toFixed(2));
}
triangleArea(["20", "30"]);
triangleArea(["15", "35"]);
triangleArea(["7.75", "8.45"]);
triangleArea(["1.23456", "4.56789"]);