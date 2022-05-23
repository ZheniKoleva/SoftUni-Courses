function argumentInfo(...arguments){
    const dataTypes = {};

    arguments.forEach(x => {
        const type = typeof x;

        if (!dataTypes.hasOwnProperty(type)) {
            dataTypes[type] = 0;
        }

        dataTypes[type]++; 
        console.log(`${type}: ${x}`);      
    });

    const sorted = Object.keys(dataTypes).sort((a, b) => dataTypes[b] - dataTypes[a]);
    sorted.forEach(key => console.log(`${key} = ${dataTypes[key]}`));
}

argumentInfo('cat', 42, function () { console.log('Hello world!'); });