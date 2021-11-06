function trainTheTrainers(input) {
    let juryCount = parseInt(input.shift());
    
    let presentationCount = 0;
    let finalGrade = 0;
    let presentationName = input.shift();

    while (presentationName !== "Finish") {
        presentationCount++;
        let sumGradesPerPresentation = 0;

        for (let grades = 1; grades <= juryCount; grades++){
            sumGradesPerPresentation += Number(input.shift());            
        }

        let avgPerPresentation = sumGradesPerPresentation / juryCount;
        finalGrade += avgPerPresentation;
        console.log(`${presentationName} - ${avgPerPresentation.toFixed(2)}.`);
        presentationName = input.shift();
    }

    console.log(`Student's final assessment is ${(finalGrade / presentationCount).toFixed(2)}.`);
}
trainTheTrainers(["2",
"While-Loop",
"6.00",
"5.50",
"For-Loop",
"5.84",
"5.66",
"Finish"]);

trainTheTrainers(["3",
"Arrays",
"4.53",
"5.23",
"5.00",
"Lists",
"5.83",
"6.00",
"5.42",
"Finish"]);

trainTheTrainers(["2",
"Objects and Classes",
"5.77",
"4.23",
"Dictionaries",
"4.62",
"5.02",
"RegEx",
"2.88",
"3.42",
"Finish"]);


