function timeToWalk(stepsCount, footprintInMeters, speedKmPerHour){
    let distanceInMeters = stepsCount * footprintInMeters;
    let speedMetersPerSecond = speedKmPerHour * 1000 / 3600;
    
    let additionalTimeInSeconds = (Math.floor(distanceInMeters / 500)) * 60;
    let timeInSeconds = (distanceInMeters / speedMetersPerSecond) + additionalTimeInSeconds;

    let hours = (Math.floor(timeInSeconds / 3600)).toString().padStart(2, 0);
    timeInSeconds %= 3600;
    let minutes = (Math.floor(timeInSeconds / 60)).toString().padStart(2, 0);  
    let seconds = (Math.round(timeInSeconds % 60)).toString().padStart(2, 0);

    console.log(`${hours}:${minutes}:${seconds}`);
}

timeToWalk(4000, 0.60, 5);
timeToWalk(2564, 0.70, 5.5);