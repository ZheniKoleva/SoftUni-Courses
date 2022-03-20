import { cats } from './catSeeder.js';
import { render } from '../node_modules/lit-html/lit-html.js';
import { allCatsTemplate } from './templates/templates.js';

const allCatsSection = document.querySelector('#allCats');
render(allCatsTemplate(cats, toggleStatusCode), allCatsSection);

function toggleStatusCode(e) {
    const button = e.target;
    const divToShow = button.nextElementSibling;

    button.textContent = button.textContent == 'Show status code'
        ? 'Hide status code'
        : 'Show status code';

    divToShow.style.display = button.textContent == 'Show status code'
        ? 'none'
        : 'block';
}
