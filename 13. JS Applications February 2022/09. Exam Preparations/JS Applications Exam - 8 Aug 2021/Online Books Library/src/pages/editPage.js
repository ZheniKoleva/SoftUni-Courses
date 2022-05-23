import { editTemplate } from "./../templates/editTemplate.js"; 
import libraryService from "../services/libraryService.js";
import validations from './../services/validations.js';

async function getView(cntx) {
    const bookId = cntx.params.id;
    const binded = update.bind(null, cntx);

    try {
        const bookData = await libraryService.getById(bookId);
        const template = editTemplate(bookData, binded);
        cntx.renderView(template);
        
    } catch (error) {
        alert(error.message);
    }    
}

async function update(cntx, e) {
    e.preventDefault();

    const bookId = cntx.params.id;
    const form = e.target;
    const formData = new FormData(form);
    const newData = Object.fromEntries(formData);    

    try {
        validations.validateInputs(newData); 
        await libraryService.updateBook(newData, bookId);        
        cntx.page.redirect(`/details/${bookId}`);

    } catch (error) {
        alert(error.message);
    }
}

export default {
    getView
}