function numbersWithStep3(input) {
    let number = parseInt(input[0]);

    for (let i = 1; i <= number; i += 3) {
        console.log(i);        
    }
}
numbersWithStep3(["10"]);
console.log(`---------------`);
numbersWithStep3(["7"]);
console.log(`---------------`);
numbersWithStep3(["15"]);


