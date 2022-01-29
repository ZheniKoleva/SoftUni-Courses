function solve() {
    const addSection = document.querySelector('.gray').parentElement.parentElement;
    const inputFormElement = addSection.querySelector('form');
    inputFormElement.querySelector('#add').addEventListener('click', addTask);

    const openSection = document.querySelector('.orange').parentElement.parentElement;
    const openSectionDivElement = openSection.querySelector('div:nth-of-type(2)');

    const inProgressSection = document.querySelector('.yellow').parentElement.parentElement;
    const inProgressDivElement = inProgressSection.querySelector('#in-progress');
    
    const completeSection = document.querySelector('.green').parentElement.parentElement;    
    const completedDivElement = completeSection.querySelector('div:nth-of-type(2)');

    function addTask(e){
        e.preventDefault();
        const taskElement = inputFormElement.querySelector('#task');
        const descrElement = inputFormElement.querySelector('#description');
        const dateElement = inputFormElement.querySelector('#date');

        if (taskElement.value && descrElement.value && dateElement.value) {
            const articleElement = document.createElement('article');

            const h3Element = document.createElement('h3');
            h3Element.textContent = taskElement.value;

            const decsriptionPElement = document.createElement('p');
            decsriptionPElement.textContent = `Description: ${descrElement.value}`;

            const dueDateElement = document.createElement('p');
            dueDateElement.textContent = `Due Date: ${dateElement.value}`;

            const divElement = document.createElement('div');
            divElement.classList.add('flex');

            const startButtonElement = document.createElement('button');
            startButtonElement.classList.add('green');
            startButtonElement.textContent = 'Start';
            startButtonElement.addEventListener('click', startTask);

            const deleteButtonElement = document.createElement('button');
            deleteButtonElement.classList.add('red');
            deleteButtonElement.textContent = 'Delete';
            deleteButtonElement.addEventListener('click', deleteTask);

            divElement.appendChild(startButtonElement);
            divElement.appendChild(deleteButtonElement);

            articleElement.appendChild(h3Element);
            articleElement.appendChild(decsriptionPElement);
            articleElement.appendChild(dueDateElement);
            articleElement.appendChild(divElement);

            openSectionDivElement.appendChild(articleElement);
        }

        taskElement.value = '';
        descrElement.value = '';
        dateElement.value = '';
    }

    function startTask(e){
        const startButton = e.target;
        const task = startButton.parentElement.parentElement;
        startButton.remove();

        const finishElement = document.createElement('button');
        finishElement.classList.add('orange');
        finishElement.textContent = 'Finish';
        finishElement.addEventListener('click', finishTask); 
        task.querySelector('div').appendChild(finishElement);       

        inProgressDivElement.appendChild(task);
    }

    function deleteTask(e){
        const taskToremove = e.target.parentElement.parentElement;
        taskToremove.remove();        
    }

    function finishTask(e){
        const finishedTask = e.target.parentElement.parentElement;
        finishedTask.querySelector('div').remove();

        completedDivElement.appendChild(finishedTask);
    }
}