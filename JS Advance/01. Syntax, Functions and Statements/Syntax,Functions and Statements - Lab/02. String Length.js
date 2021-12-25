function stringLength(first, second, third){
    let lengthSum = first.length + second.length + third.length;
    let average = Math.floor(lengthSum / 3);

    console.log(lengthSum);
    console.log(average);
}

stringLength('chocolate', 'ice cream', 'cake');
stringLength('pasta', '5', '22.3');