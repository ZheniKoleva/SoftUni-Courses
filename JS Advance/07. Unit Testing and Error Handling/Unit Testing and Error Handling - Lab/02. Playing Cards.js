function createCard(inputFace, inputSuit){
    const faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
    const suits = {
        S: '\u2660',
        H: '\u2665',
        D: '\u2666',
        C: '\u2663',
    }

    if (!faces.includes(inputFace) || !suits.hasOwnProperty(inputSuit)) {
        throw new Error('Invalid face or suit');
    }

    const card = {
        face: inputFace,
        suit: suits[inputSuit],
        toString(){ return `${this.face}${this.suit}`; },
    }

    return card.toString();
}

console.log(createCard('A', 'S'));
console.log(createCard('10', 'H'));
console.log(createCard('1', 'C'));