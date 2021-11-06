function clockPart2() {
    for (let hours = 0; hours < 24; hours++) {
        for (let minutes = 0; minutes < 60; minutes++) {
            for (let seconds = 0; seconds < 60; seconds++) {
                console.log(`${hours} : ${minutes} : ${seconds}`);
            }
        }
    }
}
clockPart2();