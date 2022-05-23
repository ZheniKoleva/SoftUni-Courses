function solve() {
    const formElement = document.querySelector('#signup form');
    const addWorkerButton = formElement.querySelector('#add-worker');
    addWorkerButton.addEventListener('click', hireWorker);

    const inputElements = Array.from(formElement.querySelectorAll('input'));

    const tableBodyElement = document.querySelector('#tbody');
    const salarySpanElement = document.querySelector('#sum');

    function hireWorker(e) {
        e.preventDefault();        

        if (inputElements.every(x => x.value)) {

            const trElement = createElement('tr');

            const tdElements = inputElements
                .map(x => createElement('td', x.value))
                .forEach(x => trElement.appendChild(x));

            const tdButtonsElement = createElement('td', undefined);

            const firedButton = createElement('button', 'Fired');
            firedButton.classList.add('fired');
            firedButton.addEventListener('click', fireEmployee);

            const editButton = createElement('button', 'Edit');
            editButton.classList.add('edit');
            editButton.addEventListener('click', editEmployee);

            tdButtonsElement.appendChild(firedButton);
            tdButtonsElement.appendChild(editButton);

            trElement.appendChild(tdButtonsElement);

            tableBodyElement.appendChild(trElement);

            const salary = Number(inputElements.find(x => x.id == 'salary').value);
            salarySpanElement.textContent = (Number(salarySpanElement.textContent) + salary).toFixed(2);

            inputElements.forEach(x => x.value = '');
        }
    }

    function fireEmployee(e) {
        const employeeToFire = e.target.parentElement.parentElement;
        const children = employeeToFire.children;  

        const salary = Number(children[5].textContent);
        salarySpanElement.textContent = (Number(salarySpanElement.textContent) - salary).toFixed(2);
        
        employeeToFire.remove();
    }

    function editEmployee(e) {
        const employeeToEdit = e.target.parentElement.parentElement;
        const children = employeeToEdit.children;        

        inputElements.forEach((x, i) => x.value = children[i].textContent);

        const salary = Number(children[5].textContent);
        salarySpanElement.textContent = (Number(salarySpanElement.textContent) - salary).toFixed(2);
        
        employeeToEdit.remove();
    }

    function createElement(type, textContent) {
        const element = document.createElement(type);
        element.textContent = textContent;

        return element;
    }
}

solve();