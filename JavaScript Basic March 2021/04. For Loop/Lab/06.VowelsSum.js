function vowelsSum(input) {
    let text = input[0];
    let sum = 0;

    for (let index = 0; index < text.length; index++) {

        switch (text[index]) {
            case 'a': sum += 1; break;
            case 'e': sum += 2; break;
            case 'i': sum += 3; break;
            case 'o': sum += 4; break;
            case 'u': sum += 5; break;
        }
    }
    console.log(sum);
}
vowelsSum(["hello"]);
vowelsSum(["hi"]);
vowelsSum(["bamboo"]);
vowelsSum(["beer"]);