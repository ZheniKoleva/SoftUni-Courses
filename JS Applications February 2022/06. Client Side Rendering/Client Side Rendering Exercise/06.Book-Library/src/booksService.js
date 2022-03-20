import request from "./api.js";
import { allBooksTemplate, editFormTemplate, addFormTemplate } from "./templates/templates.js";
import { render } from './../../node_modules/lit-html/lit-html.js';
import { validateInputData } from './validations.js';

const mainContainer = document.querySelector('#main-container');
const formContainer = document.querySelector('#form-container');

export async function loadBooks(e) {
    const tableBody = mainContainer.querySelector('#table-body');

    try {
        const books = await request.getRequest();
        render(allBooksTemplate(books), tableBody);
    } catch (error) {
        alert(error.message)
    }
}

export async function addBook(e) {
    e.preventDefault();

    const form = e.target;
    const formData = new FormData(form);
    const bookData = Object.fromEntries(formData);

    try {
        validateInputData(bookData);
        form.reset();
        await request.postRequest(bookData);
        alert('Book added successfully!');
        await loadBooks();
    } catch (error) {
        alert(error.message);
    }
}

async function editBook(bookData) {
    render(editFormTemplate(bookData, saveBook), formContainer)
}

async function saveBook(e) {
    e.preventDefault();

    const form = e.target;
    const formData = new FormData(form);
    const bookNewData = Object.fromEntries(formData);

    const bookId = bookNewData.id;
    const bookData = {
        title: bookNewData.title,
        author: bookNewData.author
    };

    try {
        validateInputData(bookData);
        form.reset();
        await request.putRequest(bookId, bookData);
        alert('Book updated successfully!');
        await loadBooks();
        render(addFormTemplate(addBook), formContainer);
    } catch (error) {
        alert(error.message);
    }
}

async function deleteBook(bookData) {
    try {
        await request.deleteRequest(bookData._id);
        alert('Book deleted successfully!');
        await loadBooks();
        
    } catch (error) {
        alert(error.message);
    }
}

export function changeBook(e) {
    const bookToChange = {};

    const operations = {
        'edit': (bookToChange) => editBook(bookToChange),
        'delete': (bookToChange) => deleteBook(bookToChange)
    };

    if (e.target.nodeName === 'BUTTON') {
        const buttonText = e.target.textContent.toLowerCase();
        const parent = e.target.closest('tr');
        const [title, author] = parent.children;

        bookToChange.title = title.textContent;
        bookToChange.author = author.textContent;
        bookToChange._id = e.target.dataset.id;

        operations[buttonText](bookToChange);
    }
}