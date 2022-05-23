function histogram(input) {
    let numberCount = Number(input[0]);

    let p1 = 0;
    let p2 = 0;
    let p3 = 0;
    let p4 = 0;
    let p5 = 0;

    for (let index = 1; index < input.length; index++) {
        if (input[index] < 200) {
            p1++;

        }else if (input[index] < 400) {
            p2++;

        }else if (input[index] < 600) {
            p3++;
            
        }else if (input[index] < 800) {
            p4++;
            
        }else {
            p5++;            
        }        
    }

    let percentP1 = (p1 / numberCount * 100).toFixed(2);
    let percentP2 = (p2 / numberCount * 100).toFixed(2);
    let percentP3 = (p3 / numberCount * 100).toFixed(2);
    let percentP4 = (p4 / numberCount * 100).toFixed(2);
    let percentP5 = (p5 / numberCount * 100).toFixed(2);

    console.log(`${percentP1}%`);
    console.log(`${percentP2}%`);
    console.log(`${percentP3}%`);
    console.log(`${percentP4}%`);
    console.log(`${percentP5}%`); 
}

histogram(["3", "1", "2", "999"]);
histogram(["7", "800", "801", "250", "199", "399", "599", "799"]);
histogram(["9", "367", "99", "200", "799", "999", "333", "555", "111", "9"]);
histogram(["14", "53", "7", "56", "180", "450", "920", "12", "7", "150", "250", "680", "2", "600", "200"]);
