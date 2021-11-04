function countTheWords(input) {
    let text = input[0];
    let countSpaces = 0;
    let wordsCount = 1;

    for (let index = 0; index < text.length; index++) {
        if (text[index] === " ") {
            countSpaces++;
        }
        
    }
    wordsCount += countSpaces;
    if (wordsCount > 10) {
        console.log(`The message is too long to be send! Has ${wordsCount} words.`);

    }else {
        console.log(`The message was sent successfully!`);
    }
}
countTheWords(["This message has exactly eleven words. One more as it's allowed!"]);
countTheWords(["This message has ten words and you can send it!"]);