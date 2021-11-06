function vacation(input) {
    let index = 0;
    let moneyNeeded = Number(input[index++]);
    let moneyHave = Number(input[index++]);

    let daysCount = 0;
    let spendDays = 0;
    let isNotSaved = false;
    
    while (moneyHave < moneyNeeded) {
        let command = input[index++];
        let currentMoney = Number(input[index++]);
        daysCount++;

        switch (command) {
            case "save":
                moneyHave += currentMoney;
                spendDays = 0;
                break;

            case "spend":
                spendDays++;
                if (currentMoney > moneyHave) {
                    moneyHave = 0;
                }else {
                    moneyHave -= currentMoney;
                }
                break;
        }

        if (spendDays == 5) {
            isNotSaved = true;
            break;
        }
    }

    if (isNotSaved) {
        console.log("You can't save the money.\n" + `${daysCount}`);
    }else {
        console.log(`You saved the money for ${daysCount} days.`);
    }
}
vacation(["2000","1000","spend","1200","save","2000"]);
vacation(["110","60","spend","10","spend","10","spend","10","spend","10","spend","10"]);