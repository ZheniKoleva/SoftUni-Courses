function schoolarShip(input) { 
    let income = Number(input[0]);
    let grade = Number(input[1]);
    let minSalary = Number(input[2]);

    let isSocial = (income < minSalary) && (grade > 4.50);
    let isExcellent = grade >= 5.50;
    let isBoth = isSocial && isExcellent;

    let social = Math.floor(minSalary * 0.35);
    let excellent = Math.floor(grade * 25);

    if (!isSocial && !isExcellent) {
        console.log(`You cannot get a scholarship!`);

    } else if((isSocial && !isExcellent) || (isBoth && social > excellent)) {
        console.log(`You get a Social scholarship ${social} BGN`);

    }else if ((isExcellent && !isSocial) || (isBoth && excellent >= social)) {
        console.log(`You get a scholarship for excellent results ${excellent} BGN`);
    }
}
schoolarShip(["480.00", "4.60", "450.00"]);
schoolarShip(["300.00", "5.65", "420.00"]);