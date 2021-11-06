function bestPlayer(input) {
    let index = 0;
    let player = input[index++];
    let goals = Number(input[index++]);
    let bestPlayer = "";
    let maxGoals = 0;

    while (player !== "END") {
        if (goals > maxGoals) {
            bestPlayer = player; 
            maxGoals = goals;
        }

        if (goals >= 10) {
            break;
        }
        player = input[index++];
        goals = input[index++];
    }
    console.log(`${bestPlayer} is the best player!`);
    if (maxGoals >= 3) {
        console.log(`He has scored ${maxGoals} goals and made a hat-trick !!!`);

    } else {
        console.log(`He has scored ${maxGoals} goals.`);

    }
}
bestPlayer(["Neymar","2", "Ronaldo", "1", "Messi", "3", "END"]);

//bestPlayer(["Silva", "5", "Harry Kane", "10","END"]);

//bestPlayer(["Rooney","1","Junior","2"," Paolinio","2","END"]);

//bestPlayer(["Zidane", "1","Felipe","2","Johnson","4","END"]);
