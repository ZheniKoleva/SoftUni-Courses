function getSmallestElements(inputArray){
    let result = inputArray
        .map(x => x)
        .sort((x, y) => x - y)
        .slice(0, 2)
        .join(' ');
   
    console.log(result);   
}

getSmallestElements([30, 15, 50, 5]);
getSmallestElements([3, 0, 10, 4, 7, 3]);