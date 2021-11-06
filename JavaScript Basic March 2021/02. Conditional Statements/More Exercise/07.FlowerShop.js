function flowerShop(input) {
    let magnoliaCount = parseInt(input[0]);
    let hyacinthCount = parseInt(input[1]);
    let roseCount = parseInt(input[2]);
    let cactusCount = parseInt(input[3]);
    let presentPrice = Number(input[4]);

    const magnoliaPrice = 3.25;
    const hyacinthPrice = 4.00;
    const rosePrice = 3.50;
    const cactusPrice = 8.00;

    let totalSum = (magnoliaCount * magnoliaPrice) + (hyacinthCount * hyacinthPrice) +
     (roseCount * rosePrice) + (cactusCount * cactusPrice);
     totalSum -= totalSum * 0.05;
     let difference = Math.abs(totalSum - presentPrice);

     if (totalSum >= presentPrice) {
         console.log(`She is left with ${Math.floor(difference)} leva.`);
     } else {
         console.log(`She will have to borrow ${Math.ceil(difference)} leva.`);
     }
}
flowerShop(["2", "3", "5", "1", "50"]);
flowerShop(["15", "7", "5", "10", "100"]);