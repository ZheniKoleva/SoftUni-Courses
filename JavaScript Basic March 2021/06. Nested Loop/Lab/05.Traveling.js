function traveling(input) {
    let destination = input.shift();    

    while (destination !== "End") {
        let budget = Number(input.shift());
        let currentSum = 0;

        while (currentSum < budget) {
            currentSum += Number(input.shift());
        }

        console.log(`Going to ${destination}!`);
        destination = input.shift();
    }
    
}
traveling(["Greece",
"1000",
"200",
"200",
"300",
"100",
"150",
"240",
"Spain",
"1200",
"300",
"500",
"193",
"423",
"End"]);

traveling(["France",
"2000",
"300",
"300",
"200",
"400",
"190",
"258",
"360",
"Portugal",
"1450",
"400",
"400",
"200",
"300",
"300",
"Egypt",
"1900",
"1000",
"280",
"300",
"500",
"End"]);

