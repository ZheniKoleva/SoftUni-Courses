function townPopulation(inputArray){
    const towns = {};    

    for (const townData of inputArray) {
        const extracted = townData.split(' <-> ');
        const currentTown = extracted[0];
        let population = Number(extracted[1]);

        if (towns.hasOwnProperty(currentTown)) {
            population += towns[currentTown];
        }

        towns[currentTown] = population; 
    }

   for (const town in towns) {
       console.log(`${town} : ${towns[town]}`);
   }
}

townPopulation([
    'Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000'
]);

townPopulation([
    'Istanbul <-> 100000',
    'Honk Kong <-> 2100004',
    'Jerusalem <-> 2352344',
    'Mexico City <-> 23401925',
    'Istanbul <-> 1000'
]);