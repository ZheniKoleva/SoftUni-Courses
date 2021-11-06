function godzillaVsKong(input) {
    let budget = Number(input[0]);
    let extras= parseInt(input[1]);
    let clothPricePerOne = Number(input[2]);
    
    let decor = budget * 0.10;
    if (extras > 150) {
        clothPricePerOne -= clothPricePerOne * 0.10;
    }

    let totalSum = (clothPricePerOne * extras) + decor;
    let difference = Math.abs(budget - totalSum);

    if (totalSum > budget) {
        console.log(`Not enough money!\nWingard needs ${difference.toFixed(2)} leva more.`);

    } else {
        console.log(`Action!\nWingard starts filming with ${difference.toFixed(2)} leva left.`);
    }    
}
godzillaVsKong(["20000", "120", "55.5"]);
godzillaVsKong(["15437.62", "186", "57.99"]);
godzillaVsKong(["9587.88", "222", "55.68"]);