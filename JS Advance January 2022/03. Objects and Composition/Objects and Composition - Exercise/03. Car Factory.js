function generateCar(carTemplate){
    debugger
    const car = {
        model: carTemplate.model,
        engine: createEngine(carTemplate.power),
        carriage: createCarriage(carTemplate.color, carTemplate.carriage),
        wheels: createWheels(carTemplate.wheelsize)
    }

    return car;    

    function createEngine(powerValue){
        const enginesTypes = {
            'Small engine': {power: 90, volume: 1800},
            'Normal engine': {power: 120, volume: 2400},
            'Monster engine': {power: 200, volume: 3500},
        };

        let engineToReturn = '';

        if (powerValue <= 90) {
            engineToReturn = 'Small engine';
        }else if(powerValue <= 120){
            engineToReturn = 'Normal engine';
        }else if(powerValue <= 200){
            engineToReturn = 'Monster engine';
        }

        return enginesTypes[engineToReturn];
    }

    function createCarriage(color, carriageType){
        const carriages = {
            'hatchback': {type: 'hatchback', color: null},
            'coupe': {type: 'coupe', color: null}
        };

        let carriage = carriages[carriageType.toLowerCase()];
        carriage.color = color;

        return carriage;
    }

    function createWheels(wheelSize){
        const size = wheelSize % 2 == 0 ? wheelSize - 1 : wheelSize;
        return new Array(4).fill(size);
    }
}

console.log(generateCar(
    {
        model: 'VW Golf II',
        power: 90,
        color: 'blue',
        carriage: 'hatchback',
        wheelsize: 14
    }
));

console.log(generateCar(
    {
        model: 'Opel Vectra',
        power: 110,
        color: 'grey',
        carriage: 'coupe',
        wheelsize: 17
    }
));