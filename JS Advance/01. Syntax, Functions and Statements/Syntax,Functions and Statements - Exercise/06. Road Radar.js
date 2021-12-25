function roadRadar(speed, area){
    let speedLimits = {
        'motorway': 130,
        'interstate': 90,
        'city': 50,
        'residential': 20
    };

    let speedLimit = speedLimits[area];
    let result;

    if (speed <= speedLimit) {
        result = `Driving ${speed} km/h in a ${speedLimit} zone`;

    }else{
        let difference = speed - speedLimit;
        let drivingStatus = '';

        switch (true) {
            case difference <= 20: drivingStatus = 'speeding'; break;
            case difference <= 40: drivingStatus = 'excessive speeding'; break;        
            default: drivingStatus = 'reckless driving'; break;
        }

        result = `The speed is ${difference} km/h faster than the allowed speed of ${speedLimit} - ${drivingStatus}`;
    }   
    
    console.log(result);
}

roadRadar(40, 'city');
roadRadar(21, 'residential');
roadRadar(120, 'interstate');
roadRadar(200, 'motorway');