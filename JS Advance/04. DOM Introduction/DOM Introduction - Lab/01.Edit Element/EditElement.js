function editElement(htmlReference, match, replacer) {
    let text = htmlReference.textContent;
    let matcher = new RegExp(match, 'g');
    let newText = text.replace(matcher, replacer);
    htmlReference.textContent = newText;
}