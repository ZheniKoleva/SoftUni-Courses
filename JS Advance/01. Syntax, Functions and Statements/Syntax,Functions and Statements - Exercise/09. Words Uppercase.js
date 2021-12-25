function upperCase(input){
    let regexPattern = /\w+/g;   

    let result = input
        .match(regexPattern)
        .join(', ')
        .toUpperCase();

    console.log(result);   
}

upperCase('Hi, how are you?');
upperCase('hello');