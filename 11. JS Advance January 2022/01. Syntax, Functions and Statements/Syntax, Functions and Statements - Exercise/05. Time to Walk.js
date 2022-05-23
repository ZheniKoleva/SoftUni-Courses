function timeToWalk(stepsCount, footprintInMeters, speedKmPerHour){
    const speedMetersPerSecond = speedKmPerHour * 1000 / 3600;
    const distanceInMeters = stepsCount * footprintInMeters;
    
    const additionalTimeInSeconds = Math.floor(distanceInMeters / 500) * 60;
    let timeInSeconds = (distanceInMeters / speedMetersPerSecond) + additionalTimeInSeconds;

    const hours = (Math.floor(timeInSeconds / 3600)).toString().padStart(2, 0);
    timeInSeconds %= 3600;
    const minutes = (Math.floor(timeInSeconds / 60)).toString().padStart(2, 0);  
    const seconds = (Math.round(timeInSeconds % 60)).toString().padStart(2, 0);

    console.log(`${hours}:${minutes}:${seconds}`);
}

timeToWalk(4000, 0.60, 5);
timeToWalk(2564, 0.70, 5.5);