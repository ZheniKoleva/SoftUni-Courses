function graduation(input) {
    let index = 0;
    let studentname = input[index++];

    let sumGrades = 0.00;
    let level = 0;
    let failed = 0;
    let isExpelled = false;
    
    while (level < 12) {
        let grade = Number(input[index++]);
        if (grade < 4.00) {
            failed++;
            if (failed > 1) {
                isExpelled = true;
                break;
            }
        }
        sumGrades += grade;
        level++;        
    }

    if (isExpelled) {
        console.log(`${studentname} has been excluded at ${level} grade`);

    }else {
        console.log(`${studentname} graduated. Average grade: ${(sumGrades / 12).toFixed(2)}`);
    }
}
graduation(["Gosho", 
"5",
"5.5",
"6",
"5.43",
"5.5",
"6",
"5.55",
"5",
"6",
"6",
"5.43",
"5"]);
console.log(`-----------------`);
graduation(["Mimi", 
"5",
"6",
"5",
"6",
"5",
"6",
"6",
"2",
"3"]);

