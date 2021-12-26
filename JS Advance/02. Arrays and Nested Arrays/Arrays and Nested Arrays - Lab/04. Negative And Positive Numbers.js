function getOrderedArray(inputArray){
    let sortedArray = [];  
      
    inputArray.forEach(x => x < 0 ? sortedArray.unshift(x) : sortedArray.push(x));  

    sortedArray.forEach(x => console.log(x));
}

getOrderedArray([7, -2, 8, 9]);
getOrderedArray([3, -2, 0, -1]);