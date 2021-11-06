function pets(input) {
   let daysCount = parseInt(input[0]);
   let foodLeftKg = parseInt(input[1]);
   let foodPerDayDog = Number(input[2]);
   let foodPerDayCat = Number(input[3]);
   let foodPerDayTurtleGr = Number(input[4]);

   let eatenTotal = (foodPerDayDog + foodPerDayCat + (foodPerDayTurtleGr / 1000)) * daysCount;
   let difference = Math.abs(foodLeftKg - eatenTotal);

   if (foodLeftKg >= eatenTotal) {
       console.log(`${Math.floor(difference)} kilos of food left.`);
   } else {
       console.log(`${Math.ceil(difference)} more kilos of food are needed.`);
   }
}
pets(["2", "10", "1", "1", "1200"]);
pets(["5", "10", "2.1", "0.8", "321"]);