function onTimeForTheExam(input) {
    let examHour = parseInt(input[0]);
    let examMinute = parseInt(input[1]);
    let arrivalHour = parseInt(input[2]);
    let arrivalMinute = parseInt(input[3]);

    let examTime = examHour * 60 + examMinute;
    let arrivalTime = arrivalHour * 60 + arrivalMinute;

    let isOnTime = (examTime >= arrivalTime) && (examTime - arrivalTime <= 30);
    let isEarly = (examTime > arrivalTime) && (examTime - arrivalTime > 30);
    let isLate = arrivalTime > examTime;

    let difference = Math.abs(examTime - arrivalTime);
    let hour = Math.floor(difference / 60);
    let minutes = difference % 60;

    if (isOnTime) {
        console.log("On time");
        if (difference !== 0) {
            console.log(`${minutes} minutes before the start`);
        }

    }else if (isEarly) {
        console.log("Early");
        if (hour == 0) {
            console.log(`${minutes} minutes before the start`);

        }else {
            if (minutes < 10) {
                console.log(`${hour}:0${minutes} hours before the start`)
            }else {
                console.log(`${hour}:${minutes} hours before the start`)
            }
            
        }
    }else if (isLate) {
        console.log("Late");
        if (hour == 0) {
            console.log(`${minutes} minutes after the start`);

        }else {
            if (minutes < 10) {
                console.log(`${hour}:0${minutes} hours after the start`)
            }else {
                console.log(`${hour}:${minutes} hours after the start`)
            }            
        }
    }
}
onTimeForTheExam(["9", "30", "9", "50"]);

onTimeForTheExam(["9", "00", "8", "30"]);

onTimeForTheExam(["16", "00", "15", "00"]);

onTimeForTheExam(["9", "00", "10", "30"]);

onTimeForTheExam(["14", "00", "13", "55"]);

onTimeForTheExam(["11", "30", "8", "12"]);

onTimeForTheExam(["10", "00", "10", "00"]);

onTimeForTheExam(["11", "30", "10", "55"]);

onTimeForTheExam(["11", "30", "12", "29"])









