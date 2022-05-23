function cookingByNumber(startNumber, arg1, arg2, arg3, arg4, arg5) {
    let startPoint = Number(startNumber);
    const commands = [arg1, arg2, arg3, arg4, arg5];

    const operations = {
        chop: (num) => num /= 2,
        dice: (num) => num = Math.sqrt(num),
        spice: (num) => ++num,
        bake: (num) => num *= 3,
        fillet: (num) => num *= 0.80
    };  
    
    commands.forEach(x => {
        startPoint = operations[x](startPoint);
        console.log(startPoint);
    });
}

cookingByNumber('32', 'chop', 'chop', 'chop', 'chop', 'chop');
cookingByNumber('9', 'dice', 'spice', 'chop', 'bake', 'fillet');