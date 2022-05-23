function printDayOfWeek(input){    
    let days = {
        'Monday': 1,
        'Tuesday': 2,
        'Wednesday': 3,
        'Thursday': 4,
        'Friday': 5,
        'Saturday': 6,
        'Sunday': 7
    };

    console.log(days.hasOwnProperty(input) ? days[input] : 'error');
}

printDayOfWeek('Monday');
printDayOfWeek('Friday');
printDayOfWeek('Invalid');