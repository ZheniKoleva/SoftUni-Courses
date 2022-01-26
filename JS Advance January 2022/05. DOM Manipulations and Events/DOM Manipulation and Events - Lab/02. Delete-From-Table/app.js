function deleteByEmail() {
    const inputElement = document.querySelector('input[type="text"]');
    const resultElement = document.querySelector('#result');
    const emailElements = Array
        .from(document.querySelectorAll('tbody tr td:nth-of-type(2)'));

    const elementToRemove = emailElements.find(x => x.textContent == inputElement.value);

    if (elementToRemove) {
         elementToRemove.parentElement.remove();        
    } 

    resultElement.textContent = elementToRemove ? 'Deleted.' : 'Not found.';
}