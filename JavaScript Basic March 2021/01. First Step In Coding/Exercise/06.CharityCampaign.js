function charityCampaign(input) {
    let daysCount = Number(input[0]);
    let chefsCount = Number(input[1]);
    let cakesCount = Number(input[2]);
    let wafflesCount = Number(input[3]);
    let pancakesCount = Number(input[4]);

    const cakePrice = 45.00;
    const wafflePrice = 5.80;
    const pancakePrice = 3.20;

    let cakeSum = cakePrice * cakesCount;
    let waffelSum = wafflePrice * wafflesCount;
    let pancakeSum = pancakePrice * pancakesCount;

    let finalSum = (cakeSum + waffelSum + pancakeSum) * chefsCount * daysCount;
    finalSum -= finalSum / 8;
    console.log(finalSum);    
}
charityCampaign(["23", "8", "14", "30", "16"]);
charityCampaign(["131", "5", "9", "33", "46"]);