function metricConvertor(input) {
    let value = Number(input[0]);
    let inputMetric = input[1];
    let outputMetric = input[2];

    if (inputMetric === "mm") {
        value /= 1000;
    } else if (inputMetric === "cm") {
        value /= 100;
    }

    if (outputMetric === "mm") {
        value *= 1000;
    } else if (outputMetric === "cm") {
        value *= 100;
    }

    console.log(value.toFixed(3));
}
metricConvertor(["12","mm","m"]);
metricConvertor(["150","m","cm"]);
metricConvertor(["45","cm","mm"]);
