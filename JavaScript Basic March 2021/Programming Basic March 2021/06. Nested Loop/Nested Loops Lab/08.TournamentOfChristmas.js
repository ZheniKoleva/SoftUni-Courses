function tournamemnt(input) {
    let daysCount = parseInt(input.shift());

    let moneyWon = 0.0;
    let daysWon = 0;
    let daysLose = 0;
    
    for (let day = 1; day <= daysCount; day++) {
        let sport = input.shift();
        
        let moneyWonPerDay = 0.0;
        let winsCount = 0;
        let loseCount = 0;

        while (sport !== "Finish") {
            let result = input.shift();

            switch (result) {
                case "win":
                    winsCount++;
                    moneyWonPerDay += 20;
                    break;            
                case "lose":
                    loseCount++;
                    break;
            }

            sport = input.shift();
        }

        if (winsCount > loseCount) {
            moneyWonPerDay *= 1.10;
            daysWon++;
        }else {
            daysLose++;
        }

        moneyWon += moneyWonPerDay;
    }

    if (daysWon > daysLose) {
        moneyWon *= 1.20;
        console.log(`You won the tournament! Total raised money: ${moneyWon.toFixed(2)}`);

    }else {
        console.log(`You lost the tournament! Total raised money: ${moneyWon.toFixed(2)}`);
    }
}
tournamemnt(["2",
"volleyball",
"win",
"football",
"lose",
"basketball",
"win",
"Finish",
"golf",
"win",
"tennis",
"win",
"badminton",
"win",
"Finish"]);

tournamemnt(["3",
    "darts",
    "lose",
    "handball",
    "lose",
    "judo",
    "win",
    "Finish",
    "snooker",
    "lose",
    "swimming",
    "lose",
    "squash",
    "lose",
    "table tennis",
    "win",
    "Finish",
    "volleyball",
    "win",
    "basketball",
    "win",
    "Finish"]);

