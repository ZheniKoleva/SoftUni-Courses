function PCStore(input) {
    let processorPrice = Number(input.shift());
    let videoPrice = Number(input.shift());
    let memoryPrice = Number(input.shift());
    let memoryCount = parseInt(input.shift());
    let discountPercent = Number(input.shift());

    const dolarToBgn = 1.57;

    let totalSum = processorPrice + videoPrice;
    totalSum -= totalSum * discountPercent;
    totalSum += memoryCount * memoryPrice;
    totalSum = totalSum * dolarToBgn;

    console.log(`Money needed - ${totalSum.toFixed(2)} leva.`);
}
PCStore(["500",
"200",
"80",
"2",
"0.05"]);

PCStore(["1200",
"850",
"120",
"4",
"0.1"]);

PCStore(["200",
"100",
"80",
"1",
"0.01"]);


