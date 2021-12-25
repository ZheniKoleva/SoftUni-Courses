function mathOperations(firstDigit, secondDigit, operator){
    let result;

    if (operator == '+') {
        result = firstDigit + secondDigit;

    } else if(operator == '-'){
        result = firstDigit - secondDigit;

    }else if(operator == '*'){
        result = firstDigit * secondDigit;

    }else if(operator == '/'){
        result = firstDigit / secondDigit;

    }else if(operator == '%'){
        result = firstDigit % secondDigit;
        
    }else if(operator == '**'){
        result = firstDigit ** secondDigit;
    }

    console.log(result);
}

mathOperations(5, 6, '+');
mathOperations(3, 5.5, '*');