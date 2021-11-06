function barcodeGenerator(input){
    let startNum = Number(input[0]);
    let end = Number(input[1]);
    let result = "";

    let first = startNum / 1000;
    let second = (startNum/ 100) % 10;
    let third = (startNum / 10) % 10;
    let last = startNum % 10;

    let startNum = input[0];
    let first = 0;
    let second = 0;
    let third = 0;
    let forth = 0;
    for (let index = 0; index < startNum.length; index++) {
        let current = Number(startNum[index]);

        if (index == 0) {
            first = current;
        } else if(index == 1){
            second = current;
        }else if(index == 2) {
            third = current;
        }else {
            forth = current;
        }

        
    }

    while (startNum !== 0) {
    
    }
    
    
    barcodeGenerator(["2345", "6789"]);