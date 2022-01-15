function getPiceOfPie(input, firstPie, secondPie){
    const firstPieIndex = input.indexOf(firstPie);
    const secondPieIndex = input.indexOf(secondPie);    

   return input.slice(firstPieIndex,secondPieIndex + 1);   
}

console.log(getPiceOfPie([
    'Pumpkin Pie',
    'Key Lime Pie',
    'Cherry Pie',
    'Lemon Meringue Pie',
    'Sugar Cream Pie'],
    'Key Lime Pie',
    'Lemon Meringue Pie'
));
console.log(getPiceOfPie([
    'Apple Crisp',
    'Mississippi Mud Pie',
    'Pot Pie',
    'Steak and Cheese Pie',
    'Butter Chicken Pie',
    'Smoked Fish Pie'],
    'Pot Pie',
    'Smoked Fish Pie'
));