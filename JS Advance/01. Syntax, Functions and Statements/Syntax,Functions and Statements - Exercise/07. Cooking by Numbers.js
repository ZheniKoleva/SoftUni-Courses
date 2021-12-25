function cookingByNumber(startNumber, arg1, arg2, arg3, arg4, arg5) {
    let startPoint = Number(startNumber);
    let commands = [arg1, arg2, arg3, arg4, arg5];

    for (const command of commands) {

        switch (command) {
            case 'chop':
                startPoint /= 2;
                break;
            case 'dice':
                startPoint = Math.sqrt(startPoint);
                break;
            case 'spice':
                startPoint++;
                break;
            case 'bake':
                startPoint *= 3;
                break;
            case 'fillet':
                startPoint *= 0.80;
                break;
        }

        console.log(startPoint);
    }
}

cookingByNumber('32', 'chop', 'chop', 'chop', 'chop', 'chop');
cookingByNumber('9', 'dice', 'spice', 'chop', 'bake', 'fillet');
