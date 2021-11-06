function happyCatParking(input) {
    let daysCount = parseInt(input.shift());
    let hoursCount = parseInt(input.shift());

    const evenHour = 1.25;
    const oddHour = 2.50;
    const other = 1.00;
    let totalSum = 0.0;

    for (let day = 1; day <= daysCount; day++){
        
        let sumPerday = 0.0;

        for (let hour = 1; hour <= hoursCount; hour++) {
            
            if (day % 2 == 0 && hour % 2 == 1) {
                sumPerday += oddHour;

            }else if (day % 2 == 1 && hour % 2 == 0) {
                sumPerday += evenHour;

            }else {
                sumPerday += other;
            }            
        }

        totalSum += sumPerday;
        console.log(`Day: ${day} - ${sumPerday.toFixed(2)} leva`);       
    }

    console.log(`Total: ${totalSum.toFixed(2)} leva`)
}
happyCatParking(["2", "5"]);
happyCatParking(["5", "2"]);