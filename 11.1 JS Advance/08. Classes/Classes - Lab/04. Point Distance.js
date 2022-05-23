class Point{
    constructor(x, y){
        this.x = x,
        this.y = y
    }

    static distance(firstPoint, secondPoint){
        const xDifference = Math.abs(firstPoint.x - secondPoint.x);
        const yDifference = Math.abs(firstPoint.y - secondPoint.y);

        const distance = Math.sqrt(Math.pow(xDifference, 2) + Math.pow(yDifference, 2));

        return distance;
    }
}

let p1 = new Point(5, 5);
let p2 = new Point(9, 8);
console.log(Point.distance(p1, p2));
