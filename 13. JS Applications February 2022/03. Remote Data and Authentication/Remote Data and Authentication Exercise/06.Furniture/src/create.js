export function createRow(furniture) {
    const row = createHTMLElement('tr');   

    const imgColumn = createHTMLElement('img', undefined, {src: `${furniture.img}`});
    const nameColumn = createHTMLElement('p', furniture.name);
    const priceColumn = createHTMLElement('p', furniture.price);
    const factorColumn = createHTMLElement('p', furniture.factor);
    const checkboxElement = createHTMLElement('input', undefined, {type: 'checkbox'});   
    
    [imgColumn, nameColumn, priceColumn, factorColumn, checkboxElement]
    .forEach(x => {
        const tdElement = createHTMLElement('td');
        tdElement.append(x);
        row.append(tdElement);
    });

    return row;
}

function createHTMLElement(tag, textContent, attributes) {
    const element = document.createElement(tag);

    if (textContent) {
        element.textContent = textContent;
    }
    
    
    if(attributes) {
        Object.keys(attributes).forEach(x => {
            element.setAttribute(`${x}`, `${attributes[x]}`);
        });       
    }
   
    return element;
}