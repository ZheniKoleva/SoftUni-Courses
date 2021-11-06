function numbersFromNTo1(input) {
    let number = parseInt(input[0]);

    for (let i = number; i >= 1; i--) {
       console.log(i);        
    }
}
numbersFromNTo1(["2"]);
numbersFromNTo1(["3"]);
numbersFromNTo1(["5"]);