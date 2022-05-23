function addItem() {
    const itemElement = document.querySelector('#newItemText');
    const valueElement = document.querySelector('#newItemValue');

    const newElement = document.createElement('option');
    newElement.value = valueElement.value;
    newElement.textContent = itemElement.value;
    
    itemElement.value = '';    
    valueElement.value = '';    
    document.querySelector('#menu').appendChild(newElement);
}