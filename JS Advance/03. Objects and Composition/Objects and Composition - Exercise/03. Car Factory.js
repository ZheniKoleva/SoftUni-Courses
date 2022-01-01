function carFactory(carTemplate){
    const car = {};

    car.model = carTemplate.model;
    car.engine = getEngine(carTemplate.power);
    car.carriage = getCarriage(carTemplate.carriage, carTemplate.color);
    car.wheels = getWheels(carTemplate.wheelsize);

    return car;

    function getEngine(power){
        const engines = {
            'small engine': {power: 90, volume: 1800},
            'normal engine': {power: 120, volume: 2400},
            'monster engine': {power: 200, volume: 3500},
        }

        switch (true) {
            case power <= 90: return engines['small engine'];
            case power <= 120: return engines['normal engine'];
            case power <= 200: return engines['monster engine'];           
        }
    }

    function getCarriage(carriageType, carColor) {
        const carriages = {
            'hatchback': {type: 'hatchback', color: null},
            'coupe': {type: 'coupe', color: null}
        };

        let carriage = carriages[carriageType.toLowerCase()];
        carriage.color = carColor;

        return carriage;
    }

    function getWheels(wheelsDiameter){
        const size = wheelsDiameter % 2 == 0 ? wheelsDiameter - 1 : wheelsDiameter;
        return new Array(4).fill(size);
    }
}

console.log(carFactory(
    {
        model: 'VW Golf II',
        power: 90,
        color: 'blue',
        carriage: 'hatchback',
        wheelsize: 14
    }
));

console.log(carFactory(
    {
        model: 'Opel Vectra',
        power: 110,
        color: 'grey',
        carriage: 'coupe',
        wheelsize: 17
    }
));