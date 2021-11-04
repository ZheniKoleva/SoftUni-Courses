function multiplyBy2(input) {
    let index = 0;    
    while (true) {

        let number = Number(input[index++]);
        if (number < 0) {
            console.log("Negative number!");
            break;
        }else {
            number *= 2;
            console.log(`Result: ${number.toFixed(2)}`);            
        }       
    }
}
multiplyBy2(["12", "43.2144", "12.3", "543.23", "-20"]);

multiplyBy2(["23.43", "12.3245", "0", "65.23432", "23", "65", "-12"]);

multiplyBy2(["-123"]);