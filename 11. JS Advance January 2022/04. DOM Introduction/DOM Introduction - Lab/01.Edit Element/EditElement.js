function editElement(reference, matchFrase, replacer) {
    const textToEdit = reference.textContent;
    const pattern = new RegExp(matchFrase, 'g');
    
    reference.textContent = textToEdit.replace(pattern, replacer);
}
