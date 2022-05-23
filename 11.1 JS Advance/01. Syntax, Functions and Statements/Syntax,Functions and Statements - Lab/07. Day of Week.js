function printDayOfWeek(input){    
    let days = new Map([
        ['Monday', 1],
        ['Tuesday', 2],
        ['Wednesday', 3],
        ['Thursday', 4],
        ['Friday', 5],
        ['Saturday', 6],
        ['Sunday', 7]
    ]);

    console.log(days.has(input) ? days.get(input) : 'error');
}

printDayOfWeek('Monday');
printDayOfWeek('Friday');
printDayOfWeek('Invalid');