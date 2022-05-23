import { createTemplate } from "./../templates/createTemplate.js";
import theaterService from './../services/theaterService.js';
import validations from './../services/validations.js';

function getView(cntx) {
    const binded = create.bind(null, cntx);
    const template = createTemplate(binded);
    cntx.renderView(template);
}

async function create(cntx, e) {
    e.preventDefault();

    const form = e.target;
    const formData = new FormData(form);
    const inputData = Object.fromEntries(formData);   

    try {
        validations.validateInputs(inputData);        
         
        await theaterService.createTheater(inputData);       
        cntx.page.redirect('/');

    } catch (error) {
        alert(error.message);
    }
}

export default {
    getView
}