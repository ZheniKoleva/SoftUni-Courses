function moon(input) {
    let avgSpeed = Number(input[0]);
    let fuelPer100Km = Number(input[1]);

    const distanceToMoon = 384400;
    const timeOnMoon = 3;

    let timeToGo = distanceToMoon / avgSpeed;
    let totalTime = Math.ceil(timeToGo * 2 + timeOnMoon);
    let fuelNeed = (fuelPer100Km * distanceToMoon * 2) /  100;

    console.log(totalTime);
    console.log(fuelNeed);
}
moon(["10000",
"5"]);
moon(["5000", "7"]);
moon(["15000",
"4"]);

