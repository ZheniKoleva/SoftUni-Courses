window.addEventListener('load', solve);

function solve() {
    const formSection = document.querySelector('#right form');
    const receivedOrdersSection = document.querySelector('#received-orders');
    const completedOrdersSection = document.querySelector('#completed-orders');

    const submitButton = formSection.querySelector('button');
    submitButton.addEventListener('click', takeOrder);

    const clearButton = completedOrdersSection.querySelector('.clear-btn');
    clearButton.addEventListener('click', clearCompletedOrders);

    function takeOrder(e) {
        e.preventDefault();

        const productType = formSection.querySelector('#type-product').value;
        const descriptionElement = formSection.querySelector('#description');
        const clientNameElement = formSection.querySelector('#client-name');
        const clientPhoneElement = formSection.querySelector('#client-phone');

        if (descriptionElement.value
            && clientNameElement.value
            && clientPhoneElement.value) {

            const divElement = createElement('div');
            divElement.classList.add('container');

            const h2Text = `Product type for repair: ${productType}`;
            const h2Element = createElement('h2', h2Text);

            const h3Text = `Client information: ${clientNameElement.value}, ${clientPhoneElement.value}`;
            const h3Element = createElement('h3', h3Text);

            const h4Text = `Description of the problem: ${descriptionElement.value}`;
            const h4Element = createElement('h4', h4Text);

            const startButton = createElement('button', 'Start repair');
            startButton.classList.add('start-btn');
            startButton.addEventListener('click', startRepair);

            const finishButton = createElement('button', 'Finish repair');
            finishButton.classList.add('finish-btn');
            finishButton.addEventListener('click', FinishRepair);
            finishButton.setAttribute('disabled', true);

            divElement.appendChild(h2Element);
            divElement.appendChild(h3Element);
            divElement.appendChild(h4Element);
            divElement.appendChild(startButton);
            divElement.appendChild(finishButton);

            receivedOrdersSection.appendChild(divElement);

            descriptionElement.value = '';
            clientNameElement.value = '';
            clientPhoneElement.value = '';
        }
    }


    function startRepair(e) {
        const parentElement = e.target.parentElement;
        e.target.setAttribute('disabled', true);

        parentElement.querySelector('.finish-btn').removeAttribute('disabled');
    }

    function FinishRepair(e) {
        const finishedOrder = e.target.parentElement;
        Array.from(finishedOrder.querySelectorAll('button'))
            .forEach(x => x.remove());

        completedOrdersSection.appendChild(finishedOrder);
    }

    function clearCompletedOrders(e) {
        Array.from(completedOrdersSection.querySelectorAll('.container'))
            .forEach(x => x.remove());
    }

    function createElement(type, textContent) {
        const element = document.createElement(type);
        element.textContent = textContent;

        return element;
    }
}