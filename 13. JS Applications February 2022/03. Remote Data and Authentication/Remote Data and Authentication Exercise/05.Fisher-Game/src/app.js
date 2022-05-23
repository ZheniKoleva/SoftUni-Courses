const userNavSection = document.querySelector('nav #user');
const guestNavSection = document.querySelector('nav #guest');
const greetingSpan = document.querySelector('.email > span');

const allCatchesDiv = document.querySelector('#catches');
const loadCatchesBtn = document.querySelector('.load');
loadCatchesBtn.addEventListener('click', loadRecords);

const session = sessionStorage.getItem('token');
const userId = session ? JSON.parse(session).userId : null;
const token = session ? JSON.parse(session).accessToken : null;

const errorMessage = 'Something went wrong! Please, try again.';

window.onload = solve();

async function solve() { 
    if (session) {
        guestNavSection.style.display = 'none';
        greetingSpan.textContent = JSON.parse(session).email;

        const addFormButton = document.querySelector('#addForm .add');
        addFormButton.disabled = false;

        const form = document.querySelector('#addForm');
        form.addEventListener('submit', addRecord);
    } else {
        userNavSection.style.display = 'none';
    }

    const catchMessage = document.createElement('p');
    catchMessage.textContent = 'Press LOAD to see all cathes!';
    allCatchesDiv.append(catchMessage);
}

async function loadRecords(e) {
    allCatchesDiv.replaceChildren();

    const url = 'http://localhost:3030/data/catches';

    try {
        const response = await fetch(url);
        validateResponse(response);
        const data = await response.json(); 
        
        Object.values(data)
            .forEach(x => {
                const currentDiv = createDivStructure(x, userId);
                allCatchesDiv.append(currentDiv);
            });

    } catch (error) {
        alert(error.message);
    }
}


async function addRecord(e) {
    e.preventDefault();

    const formData = new FormData(e.target);
    const catchData = Object.fromEntries(formData);   

    const url = 'http://localhost:3030/data/catches';    

    try {
        validateData(catchData);
        e.target.reset();

        const options = {
            method: 'post',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': token
            },
            body: JSON.stringify(catchData)
        };

        const response = await fetch(url, options);
        validateResponse(response);
        const data = await response.json();

        const newCatch = createDivStructure(data, userId);        
        allCatchesDiv.append(newCatch);       

    } catch (error) {
        alert(error.message);
    }
}


async function deleteRecord(e) {
    const elementToRemove = e.target.parentElement;
    const idToRemove = e.target.dataset.id;
    const url = `http://localhost:3030/data/catches/${idToRemove}`;

    const options = {
        method: 'delete',
        headers: {
            'X-Authorization': token
        }
    };

    try {
        const response = await fetch(url, options);
        validateResponse(response);

        elementToRemove.querySelector('.update').removeEventListener('click', updateRecord);
        e.target.removeEventListener('click', deleteRecord);
        elementToRemove.remove();
        alert('Record deleted!');       

    } catch (error) {
        alert(error.message)
    }
}


async function updateRecord(e) {
    const elementToEdit = e.target.parentElement;
    const idToEdit = e.target.dataset.id;

    const url = `http://localhost:3030/data/catches/${idToEdit}`;

    try {
        const newInputData = Object.fromEntries([...elementToEdit.querySelectorAll('input')]
            .map(x => [x.className, x.value]));

        validateData(newInputData);

        const options = {
            method: 'put',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': token
            },
            body: JSON.stringify(newInputData)
        };
       
        const response = await fetch(url, options);
        validateResponse(response);
        const data = await response.json();

        const revisedData = createDivStructure(data, userId);
        elementToEdit.replaceWith(revisedData);
        alert('Record updated!');

    } catch (error) {
        alert(error.message);
    }
}

function createDivStructure(data, userId) {
    const element = createHTMLElement('div', undefined, undefined, 'catch');

    Object.keys(data).filter(x => !x.startsWith('_'))
        .forEach(key => {
            const labelText = key === 'captureTime' ? 'Capture Time' : key.replace(key[0], key[0].toUpperCase());
            const label = createHTMLElement('label', labelText, element);
            const input = createHTMLElement('input', undefined, element, key);
            input.value = data[key];
        });

    const updateBtn = createHTMLElement('button', 'Update', element, 'update');
    updateBtn.dataset.id = data._id;
    updateBtn.disabled = userId !== data._ownerId;
    updateBtn.addEventListener('click', updateRecord);
    const deleteBtn = createHTMLElement('button', 'Delete', element, 'delete');
    deleteBtn.dataset.id = data._id;
    deleteBtn.disabled = userId !== data._ownerId;
    deleteBtn.addEventListener('click', deleteRecord);

    return element;
}


function createHTMLElement(tag, textContent, parent, className) {
    const element = document.createElement(tag);

    if (textContent) {
        element.textContent = textContent;
    }

    if (tag === 'input') {
        element.type = 'text';
    }

    if (className) {
        element.classList.add(className);
    }

    if (parent) {
        parent.append(element);
    }

    return element;
}

function validateData(catchData) {
    const regex = /^\d+$/;

    if (Object.values(catchData).some(x => !x)) {
        throw new Error('Please, fill all the fields!');
    } 

    if (!regex.test(catchData.weight)) {
        throw new Error('Weight should be a digit!');
    }

    if(!regex.test(catchData.captureTime)) {
        throw new Error('Capture Time should be a digit!');
    }
}

function validateResponse(response) {
    if (response.status !== 200) {
        throw new Error(errorMessage);
    } 
}
