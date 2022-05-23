function extractText() {
    let elements = document.querySelectorAll('#items li');
    let elementsAsArray = Array.from(elements);
    let result = document.querySelector('#result');

    let text = '';
    for (const element of elementsAsArray) {
        text += element.textContent + '\n';
    }

    result.textContent = text.trim();
}