function walking(input) {
    let index = 0;
    let stepsTarget = 10000;
    let isReached = false;

    let command = input[index];

    while (command !== "Going home") {
        stepsTarget -= parseInt(input[index++]);

        if (stepsTarget <= 0) {
            isReached = true;
            break;
        }
        command = input[index];
    }

    if (command == "Going home") {
        stepsTarget -= parseInt(input[++index]);
        if (stepsTarget <= 0) {
            isReached = true;           
        }
    }

    if (isReached) {
        console.log("Goal reached! Good job!\n" +
            `${Math.abs(stepsTarget)} steps over the goal!`);

    } else {
        console.log(`${stepsTarget} more steps to reach goal.`);
    }
}
walking(["1000", "1500", "2000", "6500"]);
walking(["1500", "300", "2500", "3000", "Going home", "200"]);
walking(["1500", "3000", "250", "1548", "2000", "Going home", "2000"]);
walking(["125", "250", "4000", "30", "2678", "4682"]);
