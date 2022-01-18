function divideWithoutremainder(input) {
    let numberCount = Number(input[0]);

    let p1 = 0;
    let p2 = 0;
    let p3 = 0;    

    for (let index = 1; index < input.length; index++) {
        if (input[index] % 2 == 0) {
            p1++;
        }
        if (input[index] % 3 == 0) {
            p2++;
        }
        if (input[index] % 4 == 0) {
            p3++;            
        } 
    }

    let percentP1 = (p1 / numberCount * 100).toFixed(2);
    let percentP2 = (p2 / numberCount * 100).toFixed(2);
    let percentP3 = (p3 / numberCount * 100).toFixed(2);    

    console.log(`${percentP1}%`);
    console.log(`${percentP2}%`);
    console.log(`${percentP3}%`);    
}
divideWithoutremainder(["10", "680", "2", "600", "200", "800", "799", "199", "46", "128", "65"]);
divideWithoutremainder(["3", "3", "6", "9"]);