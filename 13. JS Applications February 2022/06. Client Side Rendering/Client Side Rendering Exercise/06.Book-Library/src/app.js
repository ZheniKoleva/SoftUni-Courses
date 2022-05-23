import { render } from './../../node_modules/lit-html/lit-html.js';
import { mainTemplate, addFormTemplate } from "./templates/templates.js";
import { loadBooks, addBook, changeBook } from './booksService.js';

const mainContainer = document.querySelector('#main-container');
const formContainer = document.querySelector('#form-container');

render(mainTemplate(loadBooks, changeBook), mainContainer);
render(addFormTemplate(addBook), formContainer);
