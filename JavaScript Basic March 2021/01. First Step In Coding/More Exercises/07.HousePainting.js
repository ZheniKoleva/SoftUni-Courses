function housePainting(input) {
    let houseHeight = Number(input[0]);
    let sideWallLenght = Number(input[1]);
    let heightOfRoof = Number(input[2]);

    const doorWidth = 1.20;
    const doorHeight = 2.00;
    let doorArea = doorHeight * doorWidth;
    const windowSide = 1.50;
    let windowArea = Math.pow(windowSide, 2);

    let frontArea = Math.pow(houseHeight, 2);
    let sideArea = houseHeight * sideWallLenght;
    let totalAreaWalls = (frontArea + sideArea) * 2 - (windowArea * 2) - doorArea ;

    let roofArea = (sideArea * 2) + (heightOfRoof * houseHeight);

    let greenPaintNeeded = totalAreaWalls / 3.4;
    let redPaintNeeded = roofArea / 4.3;

    console.log(`${greenPaintNeeded.toFixed(2)}\n${redPaintNeeded.toFixed(2)}`);
}
housePainting(["6", "10", "5.2"]);
housePainting(["10.25", "15.45", "8.88"]);