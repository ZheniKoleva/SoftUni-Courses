function grades(input) {
    let studentsCount = parseInt(input[0]);

    let sumGrades = 0.00;
    let top = 0;
    let good = 0;
    let average = 0;
    let fail = 0;

    for (let index = 1; index <= studentsCount; index++) {
        let currentGrade = Number(input[index]);
        sumGrades += currentGrade;

        if (currentGrade < 3.00) {
            fail++;
        } else if (currentGrade < 4.00) {
            average++;
        } else if (currentGrade < 5.00) {
            good++;
        } else if (currentGrade <= 6.00) {
            top++;
        }
    }

    let persentTop = (top / studentsCount * 100).toFixed(2);
    let percentGood = (good / studentsCount * 100).toFixed(2);
    let percentAverage = (average / studentsCount * 100).toFixed(2);
    let percentFail = (fail / studentsCount * 100).toFixed(2);
    let averageGrade = (sumGrades / studentsCount).toFixed(2);

    console.log(`Top students: ${persentTop}%\n`
        + `Between 4.00 and 4.99: ${percentGood}%\n`
        + `Between 3.00 and 3.99: ${percentAverage}%\n`
        + `Fail: ${percentFail}%\n` + `Average: ${averageGrade}`);
}
grades(["10", "3.00", "2.99", "5.68", "3.01", "4", "4", "6.00", "4.50", "2.44", "5"]);
grades(["6", "2", "3", "4", "5", "6", "2.2"]);