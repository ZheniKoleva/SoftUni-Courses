function attachEvents() {
    document.querySelector('#btnLoad').addEventListener('click', loadContacts);
    document.querySelector('#btnCreate').addEventListener('click', createContacts);
    document.querySelector('#phonebook').addEventListener('click', deleteContact);
}

async function loadContacts() {
    const ulPhonebook = document.querySelector('#phonebook');
    ulPhonebook.replaceChildren();
    const url = 'http://localhost:3030/jsonstore/phonebook';

    const response = await fetch(url);
    const data = await response.json();

    Object.values(data)
        .forEach(x => {
            const liElement = createLiElement(x);
            ulPhonebook.append(liElement)
        });
}

async function createContacts() {
    const ulPhonebook = document.querySelector('#phonebook');
    const personInput = document.querySelector('#person');
    const phoneInput = document.querySelector('#phone');

    if (!personInput.value || !phoneInput.value) {
        alert('All the fields must be filled!');
        personInput.value = '';
        phoneInput.value = '';
        return;
    }

    const url = 'http://localhost:3030/jsonstore/phonebook';

    const data = {
        person: personInput.value,
        phone: phoneInput.value
    };

    personInput.value = '';
    phoneInput.value = '';

    const options = {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    };

    const response = await fetch(url, options);
    const newContact = await response.json();

    const newLi = createLiElement(newContact);
    ulPhonebook.append(newLi);    
}

function createLiElement(contactData) {
    const element = document.createElement('li');
    element.textContent = `${contactData.person}: ${contactData.phone}`;

    const deleteBtn = document.createElement('button');
    deleteBtn.textContent = 'Delete';
    deleteBtn.setAttribute('id', contactData._id);    
    element.append(deleteBtn);

    return element;
}

async function deleteContact(e) {

    if(e.target.nodeName !== 'BUTTON') {
        return;
    }

    const liToremove = e.target.parentElement;
    const id = e.target.id;
    const url = `http://localhost:3030/jsonstore/phonebook/${id}`;

    const options = {
        method: 'delete'
    }

    await fetch(url, options);    
    liToremove.remove();    
}

attachEvents();