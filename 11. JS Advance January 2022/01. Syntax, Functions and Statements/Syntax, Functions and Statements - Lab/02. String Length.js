function stringLength(first, second, third){
     const sumLengths = first.length + second.length + third.length;
     const average = Math.floor(sumLengths / 3);

     console.log(sumLengths);
     console.log(average);
}

stringLength('chocolate', 'ice cream', 'cake');
stringLength('pasta', '5', '22.3');
