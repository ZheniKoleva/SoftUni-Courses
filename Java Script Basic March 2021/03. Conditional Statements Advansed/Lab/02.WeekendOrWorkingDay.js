function weekendOrWorkingDay(input) {
    let day = input[0];
    let output = null;

    switch (day.toLowerCase()) {
        case "monday":
        case "tuesday":
        case "wednesday":
        case "thursday":
        case "friday": output = "Working day"; break;
        case "saturday":
        case "sunday": output = "Weekend"; break;
        default: output = "Error"; break;
    }
    console.log(output);
}
weekendOrWorkingDay(["Monday"]);
weekendOrWorkingDay(["Sunday"]);
weekendOrWorkingDay(["April"]);