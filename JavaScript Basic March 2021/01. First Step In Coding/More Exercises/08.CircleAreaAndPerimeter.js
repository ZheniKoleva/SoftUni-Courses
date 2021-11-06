function circleAreaAndPerimeter(input) {
    let radius = Number(input[0]);

    let area = Math.PI * Math.pow(radius, 2);
    let perimeter = Math.PI * radius * 2;
    console.log(`${area.toFixed(2)}\n${perimeter.toFixed(2)}`);    
}
circleAreaAndPerimeter(["3"]);
circleAreaAndPerimeter(["4.5"]);