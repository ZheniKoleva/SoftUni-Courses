function firm(input) {
    let hoursNeeded = parseInt(input[0]);
    let daysHave = parseInt(input[1]);
    let workersCountOvertime = parseInt(input[2]);

    let workHours = daysHave * 8.0;
    let hoursInTrainings = workHours * 0.10;
    let overtime = workersCountOvertime * daysHave * 2.0;
    let hoursToWork = Math.floor((workHours - hoursInTrainings) + overtime);
    let difference = Math.abs(hoursNeeded - hoursToWork);

    if (hoursNeeded <= hoursToWork) {
        console.log(`Yes!${difference} hours left.`);
    } else {
        console.log(`Not enough time!${difference} hours needed.`);
    }
}
firm(["90", "7", "3"]);
firm(["99", "3", "1"]);
firm(["50", "5", "2"]);