function addItem() {
    const parentElement = document.querySelector('#items');
    const newTextElement = document.querySelector('#newItemText');

    const liElement = document.createElement('LI');
    liElement.textContent = newTextElement.value;
    parentElement.appendChild(liElement);

    newTextElement.value = '';
}