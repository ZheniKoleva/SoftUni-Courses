function getDays(month, year){ 
    console.log(new Date(year, month, 0).getDate());
}

getDays(1, 2012);
getDays(2, 2021);
getDays(1, 2022);