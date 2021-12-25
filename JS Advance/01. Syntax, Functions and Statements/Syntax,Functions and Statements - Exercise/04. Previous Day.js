function getPrevousDay(year, month, day){
    let date = new Date(year,month - 1, day); 

    date.setDate(date.getDate() - 1);
    
    console.log(`${date.getFullYear()}-${date.getMonth() + 1}-${date.getDate()}`);

}

getPrevousDay(2016, 9, 30);
getPrevousDay(2016, 10, 1);
getPrevousDay(2021, 12, 25);