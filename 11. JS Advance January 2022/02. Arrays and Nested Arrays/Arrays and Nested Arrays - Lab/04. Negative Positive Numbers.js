function orderNumbers(input) { 
    const resultArray = [];

    input.forEach(x => x < 0 ? resultArray.unshift(x) : resultArray.push(x));  
      
    resultArray.forEach(x => console.log(x));
}

orderNumbers([7, -2, 8, 9]);
orderNumbers([3, -2, 0, -1]);