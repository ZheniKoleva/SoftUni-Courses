function register(input) {
    const towns = {};

    input
        .forEach(townData => {
            const [townName, population] = townData.split(' <-> ');

            if (!towns[townName]) {
                towns[townName] = 0;
            }

            towns[townName] += Number(population);
        });

    Object.keys(towns)
        .forEach(townName => console.log(`${townName} : ${towns[townName]}`));
}

register([
    'Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000'
]);

register([
    'Istanbul <-> 100000',
    'Honk Kong <-> 2100004',
    'Jerusalem <-> 2352344',
    'Mexico City <-> 23401925',
    'Istanbul <-> 1000'
]);