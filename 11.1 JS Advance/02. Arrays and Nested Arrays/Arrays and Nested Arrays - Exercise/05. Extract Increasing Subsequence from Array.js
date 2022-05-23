function getIncreasingSubsequence(inputArray){
    let result = [];    
    
    inputArray.reduce((result, x) => {
        if (result.length === 0 || result[result.length - 1] <= x) {
            result.push(x);
        }   
        
        return result;

    }, result);
    
    return result;
}

console.log(getIncreasingSubsequence([1, 3, 8, 4, 10, 12, 3, 2, 24]));

console.log(getIncreasingSubsequence([1, 2, 3, 4]));

console.log(getIncreasingSubsequence([20, 3, 2, 15, 6, 1]));