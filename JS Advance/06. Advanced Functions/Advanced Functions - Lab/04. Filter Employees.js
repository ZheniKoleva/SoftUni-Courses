function filterEmployees(employeesData, filterCriteria) {    
    const employees = JSON.parse(employeesData);
    const [filterKey, filterValue] = filterCriteria.split('-');

    const result = filterKey == 'all'
        ? employees
        : employees.filter(e => e[filterKey] === filterValue);
    
    printEmployees(result);   

    function printEmployees(employeesToPrint) {
        employeesToPrint
            .map(e => `${e['first_name']} ${e['last_name']} - ${e['email']}`)
            .forEach((e, i) => console.log(`${i}. ${e}`));
    }
}

filterEmployees(`[
    {
        "id": "1",
        "first_name": "Ardine",
        "last_name": "Bassam",
        "email": "abassam0@cnn.com",
        "gender": "Female"
    }, 
    {
        "id": "2",
        "first_name": "Kizzee",
        "last_name": "Jost",
        "email": "kjost1@forbes.com",
        "gender": "Female"
    },  
    {
        "id": "3",
        "first_name": "Evanne",
        "last_name": "Maldin",
        "email": "emaldin2@hostgator.com",
        "gender": "Male"
    }
]`,
    'gender-Female'
);

filterEmployees(`[
    {
        "id": "1",
        "first_name": "Kaylee",
        "last_name": "Johnson",
        "email": "k0@cnn.com",
        "gender": "Female"
    }, 
    {
        "id": "2",
        "first_name": "Kizzee",
        "last_name": "Johnson",
        "email": "kjost1@forbes.com",
        "gender": "Female"
     }, 
     {
        "id": "3",
        "first_name": "Evanne",
        "last_name": "Maldin",
        "email": "emaldin2@hostgator.com",
        "gender": "Male"
    }, 
    {
        "id": "4",
        "first_name": "Evanne",
        "last_name": "Johnson",
        "email": "ev2@hostgator.com",
        "gender": "Male"
    }
]`,
 'last_name-Johnson'
);

