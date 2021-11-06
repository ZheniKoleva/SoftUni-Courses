function weatherForecastPart2(input) {
    let degrees = Number(input[0]);

    if (degrees >= 5.00 && degrees < 12.00) {
        console.log("Cold");
    } else if (degrees >= 12.00 && degrees < 15.00) {
        console.log("Cool");
    }else if (degrees >= 15.00 && degrees <= 20.00) {
        console.log("Mild");
    }else if (degrees > 20.00 && degrees < 26.00) {
        console.log("Warm");
    }else if (degrees >= 26.00 && degrees <= 35.00) {
        console.log("Hot");
    }else {
        console.log("unknown");
    }
}
weatherForecastPart2(["16.5"]);
weatherForecastPart2(["8"]);
weatherForecastPart2(["22.4"]);
weatherForecastPart2(["26"]);
weatherForecastPart2(["0"]);