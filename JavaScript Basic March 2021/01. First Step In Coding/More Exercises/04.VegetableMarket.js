function vegetableMarket(input) {
    let vegetablesPrice = Number(input[0]);
    let fruitsPrice = Number(input[1]);
    let vegetablesAmount = parseInt(input[2]);
    let fruitsAmount = parseInt(input[3]);

    const rateBgnEur = 1.94;

    let profitsInBgn = (vegetablesPrice * vegetablesAmount) + (fruitsPrice * fruitsAmount);
    let profitsInEur = profitsInBgn / rateBgnEur;
    console.log(profitsInEur.toFixed(2));
}
vegetableMarket(["0.194", "19.4", "10", "10"]);
vegetableMarket(["1.5", "2.5", "10", "10"]);