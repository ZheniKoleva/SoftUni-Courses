function addItem() {
    let itemToAdd = document.querySelector('#newItemText').value;
    
    let createElement = document.createElement('li');
    createElement.textContent = itemToAdd;
    
    let addList = document.querySelector('#items');
    addList.appendChild(createElement);
    
    document.querySelector('#newItemText').value = '';
}