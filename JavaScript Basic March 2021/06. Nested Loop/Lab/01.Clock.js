function clock() {
    for (let hour = 0; hour < 24; hour++) {
        for (let minutes = 0; minutes < 60; minutes++) {
            console.log(`${hour}:${minutes}`);
        }        
    }
}
clock();