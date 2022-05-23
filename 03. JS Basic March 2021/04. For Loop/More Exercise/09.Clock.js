function clock() {
    for (let hours = 0; hours < 24; hours++) {
        for (let minutes = 0; minutes < 60; minutes++) {
            console.log(`${hours} : ${minutes}`);            
        }        
    }
}
clock();