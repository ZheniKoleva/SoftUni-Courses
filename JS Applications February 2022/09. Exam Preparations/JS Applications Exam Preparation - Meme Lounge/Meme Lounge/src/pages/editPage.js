import { editTemplate } from "./../templates/editTemplate.js"; 
import notifications from './../services/notifications.js'; 
import memeService from './../services/memeService.js';
import validations from './../services/validations.js';

async function getView(cntx) {
    const memeId = cntx.params.id;
    const binded = update.bind(null, cntx);

    try {
        const memeData = await memeService.getById(memeId);
        const template = editTemplate(memeData, binded);
        cntx.renderView(template);

    } catch (error) {
        alert(error.message);
    }    
}

async function update(cntx, e) {
    e.preventDefault();

    const memeId = cntx.params.id;
    const form = e.target;
    const formData = new FormData(form);
    const newData = Object.fromEntries(formData);    

    try {
        validations.validateInputs(newData); 
        
        await memeService.updateMeme(newData, memeId);        
        cntx.page.redirect(`/details/${memeId}`);

    } catch (error) {
        notifications.showNotification(error.message);
    }
}

export default {
    getView
}