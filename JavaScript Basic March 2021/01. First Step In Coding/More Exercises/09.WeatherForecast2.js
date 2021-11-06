function weatherForecast(input) {
    let weather = input[0] === "sunny" ? console.log("It's warm outside!") : console.log("It's cold outside!");
}
weatherForecast(["sunny"]);
weatherForecast(["cloudy"]);
weatherForecast(["snowy"]);