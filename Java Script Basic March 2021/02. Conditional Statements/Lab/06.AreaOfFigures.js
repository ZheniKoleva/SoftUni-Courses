function areaOfFigures(input) {
    let figureType = input[0];

    let area = 0.00;

    if (figureType === "square") {
        let side = Number(input[1]);
        area = Math.pow(side, 2);        
    } else if (figureType === "rectangle") {
        let a = Number(input[1]);
        let b = Number(input[2]);
        area = a * b;        
    }else if (figureType === "circle") {
        let radius = Number(input[1]);
        area = Math.PI * Math.pow(radius, 2);        
    } else if (figureType === "triangle") {        
        let side = Number(input[1]);
        let height = Number(input[2]);
        area = side * height / 2;        
    }

    console.log(area.toFixed(3));
}
areaOfFigures(["square", "5"]);
areaOfFigures(["rectangle", "7", "2.5"]);
areaOfFigures(["circle", "6"]);
areaOfFigures(["triangle", "4.5", "20"]);