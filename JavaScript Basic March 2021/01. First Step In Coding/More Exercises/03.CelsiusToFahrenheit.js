function celsiusToFahrenheit(input) {
    let degreesCelsius = Number(input[0]);

    let degreesFahrenheit = (degreesCelsius * 9 / 5) + 32;
    console.log(degreesFahrenheit.toFixed(2));
}
celsiusToFahrenheit(["25"]);
celsiusToFahrenheit(["0"]);
celsiusToFahrenheit(["-5.5"]);
celsiusToFahrenheit(["32.3"]);