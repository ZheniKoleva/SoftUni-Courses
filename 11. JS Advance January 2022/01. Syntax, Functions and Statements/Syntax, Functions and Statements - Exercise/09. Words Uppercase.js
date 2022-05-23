function upperCase(input) {
    let regexPattern = /\w+/g; 

    let result = [...input.matchAll(regexPattern)]
        .map(x => x[0].toUpperCase())
        .join(', ');        

    console.log(result);
}

upperCase('Hi, how are you?');
upperCase('hello');