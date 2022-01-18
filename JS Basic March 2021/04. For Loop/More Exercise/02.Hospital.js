function hospital(input) {
    let daysPeriod = parseInt(input[0]);

    let doctorsCount = 7;
    let treated = 0;
    let untreated = 0;

    for (let day = 1; day <= daysPeriod; day++) {        
        let currentPatientsCount = parseInt(input[day]);

        if (day % 3 == 0 && treated < untreated) {
            doctorsCount++;
        }

        if (currentPatientsCount <= doctorsCount) {
            treated += currentPatientsCount;

        } else {
            treated += doctorsCount;
            untreated += currentPatientsCount - doctorsCount;
        }  
    }

    console.log(`Treated patients: ${treated}.\n` + `Untreated patients: ${untreated}.`);
}
hospital(["4", "7", "27", "9", "1"]);
hospital(["6", "25", "25", "25", "25", "25", "2"]);
hospital(["3", "7", "7", "7"]);
