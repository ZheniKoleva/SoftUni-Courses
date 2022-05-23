function addItem() {
    let itemToAdd = document.querySelector('#newItemText').value;
    
    let newElement = document.createElement('li');
    newElement.textContent = itemToAdd;

    let deleteAttribute = document.createElement('a');
    let deleteText = document.createTextNode('[Delete]');
    deleteAttribute.appendChild(deleteText);
    deleteAttribute.href = '#';
    deleteAttribute.addEventListener('click', deleteItem);

    newElement.appendChild(deleteAttribute);
        
    let addList = document.querySelector('#items');
    addList.appendChild(newElement);

    document.querySelector('#newItemText').value = '';

    function deleteItem(){
        newElement.remove();
    }
}