function boomboiTask(input) {
    let startYear = parseInt(input[0]);
    let endYear = parseInt(input[1]);    
    let salary = Number(input[3]);

    let yearSalary = salary * 12;
    const daysCountLeap = 366;
    const daysCountNormal = 365;
    const daysOffPerYear = 90;   

    let daysForPeriod = 0;
    let workDaysTotal = 0;    
    let salaryTotal = 0;
    let description = "";

    for (let currentYear = startYear; currentYear <= endYear; currentYear++) {
       
        let isLeapYear = currentYear % 4 === 0 && (currentYear % 400 === 0 || currentYear % 100 !== 0);

        if (isLeapYear) {
            daysForPeriod += daysCountLeap;
            workDaysTotal += daysCountLeap - daysOffPerYear;

        }else {
            daysForPeriod += daysCountNormal;
            workDaysTotal += daysCountNormal - daysOffPerYear;           
        }      

        yearSalary = currentYear === startYear ? yearSalary : yearSalary * 1.05;
        salaryTotal += yearSalary;

        let typeYear = isLeapYear ? "366 дни" : "365 дни";
        let workDays = isLeapYear ? (daysCountLeap - daysOffPerYear) : (daysCountNormal - daysOffPerYear);
        
        description += `${currentYear}г. - има ${typeYear} - ${workDays} работни - заплата: ${(yearSalary).toFixed(2)}лв.` + "\n";
    }

    console.log(`Работните дни за периода ${startYear}-${endYear} са: ${workDaysTotal}`);
    console.log(`Получена заплата общо за периода - ${salaryTotal.toFixed(2)}лв.`);
    console.log(`Средна заплата за календарен ден - ${(salaryTotal / daysForPeriod).toFixed(2)}лв.`);
    console.log(`Описание на работните дни и промяна на заплатата по години:`);
    console.log(description);
   
}
boomboiTask(["2016", "2018", "1984", "400"]);
console.log(`-------------------------------------------------`);
boomboiTask(["1979", "1989", "1984", "400"]);
