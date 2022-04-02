import { addTemplate } from "./../templates/addTemplate.js";
import libraryService from './../services/libraryService.js';
import validations from '../services/validations.js';

function getView(cntx) {
    const binded = create.bind(null, cntx);
    const template = addTemplate(binded);
    cntx.renderView(template);
}

async function create(cntx, e) {
    e.preventDefault();

    const form = e.target;
    const formData = new FormData(form);
    const inputData = Object.fromEntries(formData);   

    try {
        validations.validateInputs(inputData);
         
        await libraryService.createBook(inputData);       
        cntx.page.redirect('/');

    } catch (error) {
        alert(error.message);
    }
}

export default {
    getView
}