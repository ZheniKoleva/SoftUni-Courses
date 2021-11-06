function challengeTheWedding(input) {
    let menCount = parseInt(input.shift());
    let womenCount = parseInt(input.shift());
    let tablesCount = parseInt(input.shift());

    let counter = 0;
    let noTablesLeft = false;
    let result = "";

    for (let men = 1; men <= menCount; men++) {
        for (let women = 1; women <= womenCount; women++) {
            
            result += `(${men} <-> ${women}) `;
            counter++;

            if (counter >= tablesCount) {
                noTablesLeft = true;
                break;
            }            
        }

        if (noTablesLeft) {
            break;
        }        
    }

    console.log(result);
    
}
challengeTheWedding(["2", "2", "6"]);
challengeTheWedding(["2", "2", "3"]);
challengeTheWedding(["5", "8", "40"]);