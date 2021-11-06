function sleepyTom(input) {
    let daysOff = parseInt(input[0]);
    let workingDays = 365 - daysOff;

    const goals = 30000;
    const minutesWorkingDays = 63;
    const minutesDaysOff = 127;

    let minutesTotal = (workingDays * minutesWorkingDays) + (daysOff * minutesDaysOff);
    let difference = Math.abs(minutesTotal - goals);
    let hoursPlay = Math.trunc(difference / 60);
    let minutesPlay = difference % 60;

    if (minutesTotal < goals) {
        console.log(`Tom sleeps well\n${hoursPlay} hours and ${minutesPlay} minutes less for play`);

    } else {
        console.log(`Tom will run away\n${hoursPlay} hours and ${minutesPlay} minutes more for play`);
    }
}
sleepyTom(["20"]);
sleepyTom(["113"]);