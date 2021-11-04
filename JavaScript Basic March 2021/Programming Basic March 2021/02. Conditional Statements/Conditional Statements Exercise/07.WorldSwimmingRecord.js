function worldSwimmingRecord(input) {
    let worldRecord = Number(input[0]);
    let distance = Number(input[1]);
    let timePerMeter = Number(input[2]);

    let timeForDistance = timePerMeter * distance;
    let delay = Math.trunc(distance / 15) * 12.5;
    timeForDistance += delay;
    let difference = timeForDistance - worldRecord;

    if (timeForDistance < worldRecord) {
        console.log(`Yes, he succeeded! The new world record is ${timeForDistance.toFixed(2)} seconds.`);
    } else {
        console.log(`No, he failed! He was ${difference.toFixed(2)} seconds slower.`);
    }
}
worldSwimmingRecord(["10464", "1500", "20"]);
worldSwimmingRecord(["55555.67", "3017", "5.03"]);
