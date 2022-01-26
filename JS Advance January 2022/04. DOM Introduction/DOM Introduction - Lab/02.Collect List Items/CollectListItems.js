function extractText() {
    const elementsText = Array.from(document.querySelectorAll('#items li'))
        .map(el => el.textContent)
        .join('\n');

    const resultElement = document.querySelector('#result');
    resultElement.textContent = elementsText;
}