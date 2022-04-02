import { createTemplate } from "./../templates/createTemplate.js";
import notifications from './../services/notifications.js'; 
import memeService from './../services/memeService.js';
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
         
        await memeService.createMeme(inputData);       
        cntx.page.redirect('/all');

    } catch (error) {
        notifications.showNotification(error.message);
    }
}

export default {
    getView
}