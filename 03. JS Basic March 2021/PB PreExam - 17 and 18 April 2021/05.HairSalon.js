function hairSalon(input) {
    let sumToReach = parseInt(input.shift());

    let sumEarned = 0;
    let isReached = false;

    let typeOfService = input.shift();

    while (typeOfService !== "closed") {

        let command = input.shift();

        switch (typeOfService) {
            case "haircut":
                if (command === "mens") {
                    sumEarned += 15;

                } else if (command === "ladies") {
                    sumEarned += 20;

                } else if (command === "kids") {
                    sumEarned += 10;
                }
                break;

            case "color":
                if (command === "touch up") {
                    sumEarned += 20;

                } else if (command === "full color") {
                    sumEarned += 30;
                }
                break;
        }

        if (sumEarned >= sumToReach) {
            isReached = true;
            break;
        }
        typeOfService = input.shift();
    }

    if (isReached) {
        console.log("You have reached your target for the day!");

    } else {
        let moneyNeed = sumToReach - sumEarned;
        console.log(`Target not reached! You need ${moneyNeed}lv. more.`);
    }

    console.log(`Earned money: ${sumEarned}lv.`);
}
hairSalon(["300",
"haircut",
"ladies",
"haircut",
"kids",
"color",
"touch up",
"closed"]);

hairSalon(["50",
"color",
"full color",
"haircut",
"ladies"]);

