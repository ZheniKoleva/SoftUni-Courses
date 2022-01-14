function circleArea(input){
    const type = typeof input;

    if (type === 'number') {
        const area = Math.PI * Math.pow(input, 2);
        result = area.toFixed(2); 

    } else {
        result = `We can not calculate the circle area, because we receive a ${type}.`;
    }

    console.log(result);
}

circleArea(5);
circleArea('name');