function getDays(month, year){
    
    let date = new Date(year, month, 0).getDate();

    console.log(date);
}

getDays(1, 2012);
getDays(2, 2021);
getDays(9, 1987);
