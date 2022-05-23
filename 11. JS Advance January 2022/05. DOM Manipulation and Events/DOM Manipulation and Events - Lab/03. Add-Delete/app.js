function addItem() {
    const parentElement = document.querySelector('#items');
    const newTextElement = document.querySelector('#newItemText');

    const liElement = document.createElement('LI');
    liElement.textContent = newTextElement.value;

    const anchorElement = document.createElement('A');
    anchorElement.href = '#';
    anchorElement.textContent = '[Delete]';
    anchorElement.addEventListener('click', (e) => {
        e.target.parentElement.remove();
    });

    liElement.appendChild(anchorElement);
    parentElement.appendChild(liElement);

    newTextElement.value = '';
}