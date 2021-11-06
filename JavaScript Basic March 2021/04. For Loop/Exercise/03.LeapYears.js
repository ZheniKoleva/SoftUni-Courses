function leapYears(input) {
    let start = Number(input[0]);
    let end = Number(input[1]);

    for (let year = start; year <= end; year += 4) {
        console.log(year);
    }
}
leapYears(["1908", "1919"]);
leapYears(["2000", "2011"]);
leapYears(["1584", "1597"]);
leapYears(["2020", "2032"]);