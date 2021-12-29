function sortArray(inputArray){

    function sortingCriteria(a, b){  
        if(a.length < b.length){
            return -1;
        }else if(a.length > b.length){
            return 1;
        }else {
            return a.localeCompare(b);
        }      
    }

    inputArray.sort(sortingCriteria);

    inputArray.forEach(x => console.log(x));
}

sortArray(['alpha', 'beta', 'gamma']);

sortArray(['Isacc', 'Theodor', 'Jack', 'Harrison', 'George']);

sortArray(['test', 'Deny', 'omen', 'Default']);