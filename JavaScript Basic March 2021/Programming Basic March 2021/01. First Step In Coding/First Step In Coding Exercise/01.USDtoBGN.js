function usdToBsn(input) {
    let usd = Number(input[0]);
    const rate = 1.79549;
    let bgn = usd * rate;
    console.log(bgn);
}
usdToBsn(["22"]);
usdToBsn(["100"]);
usdToBsn(["12.5"]);
