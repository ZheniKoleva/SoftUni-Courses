function multiplicationTable() {
    for (let first = 1; first <= 10; first++) {
        for (let second = 1; second <= 10; second++) {
           console.log(`${first} * ${second} = ${first * second}`)            
        }        
    }
}
multiplicationTable();