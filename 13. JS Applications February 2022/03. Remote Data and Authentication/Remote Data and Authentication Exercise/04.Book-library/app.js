const loadBooksBtn = document.querySelector('#loadBooks');
loadBooksBtn.addEventListener('click', loadBooks);
const table = document.querySelector('tbody');
const form = document.querySelector('form');
form.addEventListener('submit', processBook);
const formTitle = document.querySelector('form > h3');
const formBtn = document.querySelector('form button');

async function loadBooks() {    
    table.replaceChildren();

    const url = 'http://localhost:3030/jsonstore/collections/books';

    try {
        const response = await fetch(url);
        const data = await response.json();

        Object.entries(data)
            .forEach(([key, bookData]) => {
                const row = createRow(key, bookData);
                table.append(row);
            });

    } catch (error) {
        alert(error.message);
    }
}


async function processBook(e) {
    e.preventDefault();
    
    const formData = new FormData(form);
    const bookData = Object.fromEntries(formData);
    
    const idToEdit = form.dataset.bookId; 
    
    try {
        validateBookInputData(bookData);
        form.reset();

        const method = formBtn.textContent === 'Submit' ? 'post' : 'put';
        const url = formBtn.textContent === 'Submit'
            ? 'http://localhost:3030/jsonstore/collections/books'
            : `http://localhost:3030/jsonstore/collections/books/${idToEdit}`;

        const options = {
            method: method,
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(bookData)
        };

        const response = await fetch(url, options);
        const data = await response.json();

        if(formBtn.textContent === 'Submit') { 
            const newRow = createRow(data._id, data);        
            table.append(newRow);
        }else {
            const rowToReplace = table.querySelector(`tr[data-book-id="${idToEdit}"]`);
            const newRow = createRow(idToEdit, data);
            rowToReplace.replaceWith(newRow);

            formTitle.textContent = 'Form';
            formBtn.textContent = 'Submit';
            form.removeAttribute('data-bookId');
        }

    } catch (error) {
        alert(error.message)
    }
}


async function editBook(e) {
    formTitle.textContent = 'Edit Form';
    formBtn.textContent = 'Save';
    const selectedBook = e.target.closest('tr');    
    
    form.dataset.bookId = selectedBook.dataset.bookId;    

    const [title, author] = [...selectedBook.querySelectorAll('td')]
        .map(x => x.textContent);

    form['title'].value = title;
    form['author'].value = author;
}


async function deleteBook(e) {
    formTitle.textContent = 'Form';
    formBtn.textContent = 'Submit';
    form.reset();    
    
    const trToDelete = e.target.closest('tr');
    const bookId = trToDelete.dataset.bookId ;
    const [editBtn, deleteBtn] = trToDelete.querySelectorAll('button');
    editBtn.removeEventListener('click', editBook);
    deleteBtn.removeEventListener('click', deleteBook);

    const url = `http://localhost:3030/jsonstore/collections/books/${bookId}`;

    try {
        await fetch(url, { method: 'delete' });

        trToDelete.remove();
    } catch (error) {
        alert(error.message);
    }   
}

function validateBookInputData(bookData) {
    if (Object.values(bookData).some(x => !x)) {
        throw new Error('All the fields must be filled!');
    }
}

function createRow(key, bookData) {
    const trElement = createHTMLElement('tr');    
    trElement.dataset.bookId = key;

    const tdTitle = createHTMLElement('td', bookData.title, trElement);
    const tdAuthor = createHTMLElement('td', bookData.author, trElement);
    const buttonsTd = createHTMLElement('td', undefined, trElement);
    const editBtn = createHTMLElement('button', 'Edit', buttonsTd, editBook);
    const deleteBtn = createHTMLElement('button', 'Delete', buttonsTd, deleteBook);

    return trElement;
}

function createHTMLElement(type, textContent, parent, event) {
    const element = document.createElement(type);

    if (textContent) {
        element.textContent = textContent;
    }

    if (parent) {
        parent.append(element);
    }

    if (event) {
        element.addEventListener('click', event);
    }

    return element;
}