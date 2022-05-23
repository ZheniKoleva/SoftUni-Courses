function solve() {
    const resultElement = document.querySelector('#output');
    const sentences = document.querySelector('#input').value
        .split('.')
        .filter(x => x)
        .map(x => x.concat('.'));

    const paragraphsCount = Math.ceil(sentences.length / 3);

    for (let index = 0; index < paragraphsCount; index++) {
        const newParagraph = document.createElement('p');
        newParagraph.textContent = sentences.splice(0, 3).join('');

        resultElement.appendChild(newParagraph);        
    }
}