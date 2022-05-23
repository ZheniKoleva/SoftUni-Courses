function evenPositionElements(inputArray){
    let result = inputArray
        .filter((x, i) => i % 2 == 0)
        .join(' ');
   
    console.log(result);
}

evenPositionElements(['20', '30', '40', '50', '60']);
evenPositionElements(['5', '10']);