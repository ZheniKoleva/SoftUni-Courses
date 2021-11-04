function workingHour(input) {
    let hour = parseInt(input[0]);
    let dayOfWeek = input[1].toLowerCase();

    let isWorkingDay = dayOfWeek === "monday" || dayOfWeek === "tuesday"
        || dayOfWeek === "wednesday" || dayOfWeek === "thursday"
        || dayOfWeek === "friday" || dayOfWeek === "saturday";

    let isValidHour = hour >= 10 && hour <= 18;

    if (isValidHour && isWorkingDay) {
        console.log("open");
    } else {
        console.log("closed");
    }
}
workingHour(["11", "Monday"]);
workingHour(["19", "Friday"]);
workingHour(["11", "Sunday"]);