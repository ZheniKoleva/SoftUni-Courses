function solve() {
    const buttons = document.querySelectorAll('#container #exercise button');
    const generateButton = buttons[0];
    const buyButton = buttons[1];

    generateButton.addEventListener('click', generateProducts);
    buyButton.addEventListener('click', buyProducts); 

    const textAreas = document.querySelectorAll('#container #exercise textarea');
    const inputTextarea = textAreas[0];
    const outputTextarea = textAreas[1];

    function generateProducts(e){
        const table = document.querySelector('.table tbody');   
        const textField = e.target.previousElementSibling.value; // inputTextarea
        const products = JSON.parse(textField)        
           .map(p => createRowElement(p))
           .forEach(r => table.appendChild(r));       
    }
 
    function createRowElement(productData) {
        const newRow = document.createElement('tr');    

        const image = createElements('img', productData.img, 'src');       
        newRow.appendChild(image);

        const name = createElements('p', productData.name, undefined); 
        newRow.appendChild(name);

        const price = createElements('p', productData.price, undefined);        
        newRow.appendChild(price);

        const decFactor = createElements('p', productData.decFactor, undefined);
        newRow.appendChild(decFactor);

        const mark = createElements('input', 'checkbox', 'type');        
        newRow.appendChild(mark);       

        return newRow;

        function createElements(tagName, value, attribute){
            const column = document.createElement('td');
            const element = document.createElement(tagName);

            if(attribute){
               element.setAttribute(attribute, value);
            }else {
                element.textContent = value;
            }

            column.appendChild(element);
            return column;
        }
    }

    function buyProducts(){
        const boughtItems = Array.from(document.querySelectorAll('.table tbody tr'))
            .filter(tr => {
                if (tr.querySelector('td input[type="checkbox"]:checked')) {
                    return tr;
                }
            });

            let itemsNames = [];
            let totalPrice = 0;
            let decFactorSum = 0;

        boughtItems.forEach(r => {
            const children = r.children;

            itemsNames.push(children[1].textContent);
            totalPrice += Number(children[2].textContent);
            decFactorSum += Number(children[3].textContent);
        });    

        outputTextarea.textContent += `Bought furniture: ${itemsNames.join(', ')}\n`;     
        outputTextarea.textContent += `Total price: ${totalPrice.toFixed(2)}\n`;     
        outputTextarea.textContent += `Average decoration factor: ${decFactorSum/ boughtItems.length}`;     
        
    }
} 