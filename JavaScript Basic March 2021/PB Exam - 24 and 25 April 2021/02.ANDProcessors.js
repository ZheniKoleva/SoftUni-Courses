function processors(input) {
    let processorsNeeded = parseInt(input[0]);
    let employeesCount = parseInt(input[1]);
    let workDaysCount = parseInt(input[2]);

    const processorPrice  = 110.10;
    const timePerOneProcessor = 3;
    const hoursPerday = 8;

    let totalWorkHours = workDaysCount * hoursPerday * employeesCount;    
    let processorsTotal = Math.floor(totalWorkHours / timePerOneProcessor);
    
    let difference = Math.abs(processorsTotal - processorsNeeded);   

    if (processorsNeeded <= processorsTotal) {        
        let profit = difference * processorPrice;
        console.log(`Profit: -> ${profit.toFixed(2)} BGN`);

    } else {
        let lossses = processorPrice * difference;
        console.log(`Losses: -> ${lossses.toFixed(2)} BGN`)
    }
}
processors(["500",
"8",
"20"]);

processors(["150",
"7",
"18"]);
