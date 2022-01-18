function footballLeague(input) {
    let index = 0;
    let stadiumCapacity = parseInt(input[index++]);
    let fansCount = parseInt(input[index++]);

    let fansSectorA = 0;
    let fansSectorB = 0;
    let fansSectorV = 0;
    let fansSectorG = 0;

    for (let fans = 0; fans < fansCount; fans++) {
        let sector = input[index++];

        switch (sector) {
            case "A": fansSectorA++; break;
            case "B": fansSectorB++; break;
            case "V": fansSectorV++; break;
            case "G": fansSectorG++; break;
        }
    }

    console.log(`${(fansSectorA / fansCount * 100).toFixed(2)}%\n`
        + `${(fansSectorB / fansCount * 100).toFixed(2)}%\n`
        + `${(fansSectorV / fansCount * 100).toFixed(2)}%\n`
        + `${(fansSectorG / fansCount * 100).toFixed(2)}%\n`
        + `${(fansCount / stadiumCapacity * 100).toFixed(2)}%`);
}
footballLeague(["76", "10", "A", "V", "V", "V", "G", "B", "A", "V", "B", "B"]);
footballLeague(["93", "16", "A", "V", "G", "G", "B", "B", "G", "B", "A", "B", "B", "B", "A", "B", "B", "A"]);
footballLeague(["1000", "12", "A", "A", "V", "V", "A", "G", "A", "A", "V", "G", "V", "A"]);