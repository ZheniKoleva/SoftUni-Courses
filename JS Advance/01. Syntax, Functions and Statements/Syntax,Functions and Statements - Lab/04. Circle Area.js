function calculateCircleArea(input){
    let type = typeof(input);

    let result;

    if(type == 'number'){
        let area = Math.PI * Math.pow(input, 2);

        result = area.toFixed(2);
    }else {
        result = `We can not calculate the circle area, because we receive a ${type}.`;
    }

    console.log(result);
}

calculateCircleArea(5);
calculateCircleArea('name');