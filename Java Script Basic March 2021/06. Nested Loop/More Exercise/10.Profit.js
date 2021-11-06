function profit(input) {
   let coins1Lv = parseInt(input.shift()); 
   let coins2Lv = parseInt(input.shift()); 
   let notes5Lv = parseInt(input.shift()); 
    let sum = parseInt(input.shift());

    for (let one = 0; one <= coins1Lv; one++) {
        for (let two = 0; two <= coins2Lv; two++) {
            for (let five = 0; five <= notes5Lv; five++) {

                let isValid = (one * 1) + (two * 2) + (five * 5) === sum;

                if (isValid) {
                    console.log(`${one} * 1 lv. + ${two} * 2 lv. + ${five} * 5 lv. = ${sum} lv.`);
                }
            }
        }
    }
}
profit(["3", "2", "3", "10"]);
profit(["5", "3", "1", "7"]);
