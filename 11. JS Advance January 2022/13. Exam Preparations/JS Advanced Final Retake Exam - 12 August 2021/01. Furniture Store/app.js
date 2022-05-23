window.addEventListener('load', solve);

function solve() {
    const formElement = document.querySelector('form');
    const addButton = formElement.querySelector('#add');
    addButton.addEventListener('click', addFurniture);
    const furnitureListElement = document.querySelector('#furniture-list');

    const totalPriceElement = document.querySelector('.total-price');

    function addFurniture(e){
        e.preventDefault();
        const modelInput = formElement.querySelector('#model');
        const yearInput = formElement.querySelector('#year');
        const descriptionInput = formElement.querySelector('#description');
        const priceInput = formElement.querySelector('#price');    

        if (modelInput.value && descriptionInput.value && yearInput.value && priceInput.value 
            && Number(yearInput.value) > 0 && Number(priceInput.value) > 0) {
            const trElement = createElement('tr');
            trElement.classList.add('info');

            const tdModelElement = createElement('td', modelInput.value);
            const tdPriceElement = createElement('td', Number(priceInput.value).toFixed(2));

            const tdActionsElement = createElement('td');
            const moreInfoButton = createElement('button', 'More Info');
            moreInfoButton.classList.add('moreBtn');
            moreInfoButton.addEventListener('click', showMoreInfo);
            const buyButton = createElement('button', 'Buy it');
            buyButton.classList.add('buyBtn');
            buyButton.addEventListener('click', buyItem);

            tdActionsElement.appendChild(moreInfoButton);
            tdActionsElement.appendChild(buyButton);

            trElement.appendChild(tdModelElement);
            trElement.appendChild(tdPriceElement);
            trElement.appendChild(tdActionsElement);

            const trInfoElement = createElement('tr');
            trInfoElement.classList.add('hide');
            trInfoElement.style.display = 'none';

            const yearText = `Year: ${yearInput.value}`;
            const descriptionText = `Description: ${descriptionInput.value}`;

            const tdYearElement = createElement('td', yearText);
            const tdDecsrElement = createElement('td', descriptionText);
            tdDecsrElement.setAttribute('colspan', 3);

            trInfoElement.appendChild(tdYearElement);
            trInfoElement.appendChild(tdDecsrElement);

            furnitureListElement.appendChild(trElement);
            furnitureListElement.appendChild(trInfoElement);
        }

        modelInput.value = '';
        descriptionInput.value = '';
        yearInput.value = '';
        priceInput.value = '';
    }

    function showMoreInfo(e) {
        const parentElement = e.target.parentElement.parentElement;
        const furnitureList = Array.from(furnitureListElement.children);
        const parentIndx = furnitureList.indexOf(parentElement);
        const elementToShow = furnitureList[parentIndx + 1];

        e.target.textContent = e.target.textContent == 'More Info'
            ? 'Less Info'
            : 'More Info';

        elementToShow.style.display = elementToShow.style.display == 'none'
            ? 'contents'
            : 'none';
    }

    function buyItem(e) {
        const parentElement = e.target.parentElement.parentElement;
        const furnitureList = Array.from(furnitureListElement.children);
        const parentIndx = furnitureList.indexOf(parentElement);
        const elementToRemove = furnitureList[parentIndx + 1];

        const furniturePrice = Number(parentElement.children[1].textContent);

        totalPriceElement.textContent = (Number(totalPriceElement.textContent) + furniturePrice).toFixed(2);
        parentElement.remove();
        elementToRemove.remove();
    }

    function createElement(type, textContent) {
        const element = document.createElement(type);
        element.textContent = textContent;

        return element;
    }
}
