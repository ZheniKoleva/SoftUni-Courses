function getNumbersSum(start, end){
    let beginRange = Number(start);
    let endRange = Number(end);

    let result = 0;

    for (let index = beginRange; index <= endRange; index++) {
        result += index;        
    }

    console.log(result);
}

getNumbersSum('1', '5' );
getNumbersSum('-8', '20');