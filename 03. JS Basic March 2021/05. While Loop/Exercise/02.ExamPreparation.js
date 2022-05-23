function examPreparation(input) {
    let index = 0;
    let limitFailed = parseInt(input[index++]);

    let failedCount = 0;
    let sumGrades = 0.00;
    let taskCount = 0;
    let lastTask = null;
    let isFailed = false;

    let taskName = input[index++];

    while (taskName !== "Enough") {

        let grade = Number(input[index++]);

        if (grade <= 4) {
            failedCount++;

            if (failedCount >= limitFailed) {
                isFailed = true;
                break;
            }
        }

        sumGrades += grade;
        taskCount++;
        lastTask = taskName;
        taskName = input[index++];
    }

    if (isFailed) {
        console.log(`You need a break, ${failedCount} poor grades.`);

    } else {
        console.log(`Average score: ${(sumGrades / taskCount).toFixed(2)}\n` +
            `Number of problems: ${taskCount}\n` +
            `Last problem: ${lastTask}`);
    }
}
examPreparation(["3", "Money", "6", "Story","4", "Spring Time", "5", "Bus", "6", "Enough"]);
examPreparation(["2","Income","3","Game Info","6","Best Player","4"]);