function townsToJSON(inputArray) {
    let towns = [];

    let [town, latitude, longtitude] = extractData(inputArray.shift());

    for (const townData of inputArray) {
        let [townName, townLatitude, townLongtitude] = extractData(townData);

        const currentTown = {
            [town]: townName,
            [latitude]: Number(Number(townLatitude).toFixed(2)),
            [longtitude]: Number(Number(townLongtitude).toFixed(2))
        };

        towns.push(currentTown);
    }

    return JSON.stringify(towns);

    function extractData(input) {
        return input
            .split('|')
            .slice(1)
            .map(x => x.trim());
    }
}   
  

console.log(townsToJSON([
    '| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |'
]));

console.log(townsToJSON([
    '| Town | Latitude | Longitude |',
    '| Veliko Turnovo | 43.0757 | 25.6172 |',
    '| Monatevideo | 34.50 | 56.11 |'
]));