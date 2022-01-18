function logistics(input) {
    let cargoCount = parseInt(input[0]);

    const microbusPrice = 200;
    const truckPrice = 175;
    const trainPrice = 120;

    let totalSum = 0;
    let totalWeight = 0;
    let microbusCargo = 0;
    let truckCargo = 0;
    let trainCargo = 0;

    for (let index = 1; index <= cargoCount; index++) {
       let cargoWeight = parseInt(input[index]);
       totalWeight += cargoWeight;

       if (cargoWeight <= 3) {
           totalSum += cargoWeight * microbusPrice;
           microbusCargo += cargoWeight;

       } else if (cargoWeight <= 11){
           totalSum += cargoWeight * truckPrice;
           truckCargo += cargoWeight;

       }else if (cargoWeight >= 12) {
           totalSum += cargoWeight * trainPrice;
           trainCargo += cargoWeight;
       }        
    }

    let averagePrice = (totalSum / totalWeight).toFixed(2);
    let percentMicrobus = (microbusCargo / totalWeight * 100).toFixed(2);
    let percentTruck = (truckCargo / totalWeight * 100).toFixed(2);
    let percentTrain = (trainCargo / totalWeight * 100).toFixed(2);

    console.log(`${averagePrice}\n` + `${percentMicrobus}%\n` 
                + `${percentTruck}%\n` + `${percentTrain}%`);
}

logistics(["4", "1", "5", "16", "3"]);
logistics(["5", "2", "10", "20", "1", "7"]);