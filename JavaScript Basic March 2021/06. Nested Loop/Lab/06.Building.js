function building(input) {
    let floorsCount = parseInt(input[0]);
    let roomsCount = parseInt(input[1]);
    
    let result = "";
    for (let floor = floorsCount; floor >= 1 ; floor--) {
        for (let room = 0; room < roomsCount; room++) {
            
            if (floor === floorsCount) {
                result += `L${floor}${room} `;

            }else if (floor % 2 === 0) {
                result += `O${floor}${room} `;

            }else {
                result += `A${floor}${room} `;
            }            
        }  
        result += `\n`;     
        
    }
    console.log(result);
}
building(["6", "4"]);
building(["9", "5"]);
building(["4", "4"]);