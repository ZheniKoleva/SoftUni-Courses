import { render } from './../node_modules/lit-html/lit-html.js';
import { allOptionsTemplate } from './templates/template.js'
import { makeRequest } from './api.js';

const menu = document.querySelector('#menu');
const form = document.querySelector('form');
form.addEventListener('submit', addItem);

let optionsToLoad = await makeRequest();
render(allOptionsTemplate(optionsToLoad), menu);

async function addItem(e) {
    e.preventDefault();

    const formData = new FormData(form);
    const optionData = Object.fromEntries(formData);
    form.reset();

    const newOption = await makeRequest(optionData);
    optionsToLoad.push(newOption);

    render(allOptionsTemplate(optionsToLoad), menu);
}