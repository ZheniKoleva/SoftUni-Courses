function printDeckOfCards(cards) {
    let result = '';

    try {
        result = cards.map(createCard).join(' ');
        
    } catch (error) {
        result = error.message;
    }  
    
    console.log(result);
    
    function createCard(input) {
        const faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
        const suits = {
            S: '\u2660',
            H: '\u2665',
            D: '\u2666',
            C: '\u2663',
        }

        const inputFace = input.slice(0, input.length - 1);
        const inputSuit = input[input.length - 1];

        if (!faces.includes(inputFace) || !suits.hasOwnProperty(inputSuit)) {
            throw new Error(`Invalid card: ${input}`);
        }

        const card = {
            face: inputFace,
            suit: suits[inputSuit],
            toString() { return `${this.face}${this.suit}`; },
        }

        return card.toString();
    }    
}

printDeckOfCards(['AS', '10D', 'KH', '2C']);
printDeckOfCards(['5S', '3D', 'QD', '1C']);

