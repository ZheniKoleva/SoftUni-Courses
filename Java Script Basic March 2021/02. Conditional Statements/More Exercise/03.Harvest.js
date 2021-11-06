function harvest(input) {
    let wineYard = parseInt(input[0]);
    let grapesPerSqMeter = Number(input[1]);
    let wineNeeded = parseInt(input[2]);
    let workersCount = parseInt(input[3]);

    let harvest = wineYard * 0.40;
    let harvestGrapesAmount = harvest * grapesPerSqMeter;
    let producedWine = harvestGrapesAmount / 2.5;

    let difference = Math.abs(producedWine - wineNeeded);

    if (wineNeeded > producedWine) {
        console.log(`It will be a tough winter! More ${Math.floor(difference)} liters wine needed.`);

    } else {
        let winePerWorker = Math.ceil(difference / workersCount);
        console.log(`Good harvest this year! Total wine: ${Math.floor(producedWine)} liters.`);
        console.log(`${Math.ceil(difference)} liters left -> ${winePerWorker} liters per person.`);
    }
}
harvest(["650", "2", "175", "3"]);
harvest(["1020", "1.5", "425", "4"]);