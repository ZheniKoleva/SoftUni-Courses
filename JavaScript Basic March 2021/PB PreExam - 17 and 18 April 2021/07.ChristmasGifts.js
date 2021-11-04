function christmasGifts(input) {
    let index = 0;
    let command = input[index++];
  
    let adultsNumber = 0;
    let kidsNumber = 0;
    let toysMoney = 0;
    let sweatersMoney = 0;
  
    while (command !== "Christmas") {

      let num = Number(command);

      if (num <= 16) {
        kidsNumber++;
        toysMoney += 5;

      } else {
        adultsNumber++;
        sweatersMoney += 15;
      }

      command = input[index++];
    }

    console.log(`Number of adults: ${adultsNumber}`);
    console.log(`Number of kids : ${kidsNumber}`);
    console.log(`Number for toys: ${toysMoney}`);
    console.log(`Number for sweaters: ${sweatersMoney}`);
  }
  christmasGifts(["16", "20", "46", "12", "8", "20", "49", "Christmas"]);