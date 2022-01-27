function cars(inputData){   
    const cars = {};

    const carManifacturer = {
        create,
        inherit,
        set,
        print,
    };

    inputData.forEach(x => {
        const arguments = x.split(' ');
        const command = arguments.shift();
        const carName = arguments.shift();

        if (command === 'create') {            
            carManifacturer.create(carName);

            if (arguments.length) {
                const parentName = arguments[1];
                carManifacturer.inherit(carName, parentName);
            }

        }else if(command === 'set'){
            const [key, value] = arguments;
            carManifacturer.set(carName, key, value);

        }else if(command === 'print'){            
            carManifacturer.print(carName);
        }
    });
    
    function create(name){
        cars[name] = {};
    }

    function inherit(name, parent){        
        cars[name] = Object.setPrototypeOf(cars[name], cars[parent]);
    }

    function set(name, key, value){
        cars[name][key] = value;
    }

    function print(name) {
        let output = [];
        for (const key in cars[name]) {
            output.push(`${key}:${cars[name][key]}`);
        }

        console.log(output.join(','));
    }
}

cars(['create c1',
    'create c2 inherit c1',
    'set c1 color red',
    'set c2 model new',
    'print c1',
    'print c2'
]);
