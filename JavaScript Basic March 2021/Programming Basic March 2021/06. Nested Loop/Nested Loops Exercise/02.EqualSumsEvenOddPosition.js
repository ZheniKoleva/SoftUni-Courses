function equalSums(input) {
    let start = parseInt(input[0]);
    let end = parseInt(input[1]);

    let result = "";
    let hasValid = false;
    
    for (let digit = start; digit <= end; digit++) {       
        let digitAsText = "" + digit;
        let evenSum = 0;
        let oddSum = 0;

        for (let index = 0; index < digitAsText.length; index++) {
            
            if (index % 2 === 0) {
                evenSum += parseInt(digitAsText[index]);

            }else {
                oddSum += parseInt(digitAsText[index]);
            }                       
        }
        
        if (evenSum === oddSum) {
            result += digit + " ";
            hasValid = true;
        }        
    }

    if (hasValid) {
        console.log(result);
    }
}
equalSums(["100000",
"100050"]);
equalSums(["123456",
"124000"]);
equalSums(["299900",
"300000"]);
equalSums(["100115",
"100120"]);




