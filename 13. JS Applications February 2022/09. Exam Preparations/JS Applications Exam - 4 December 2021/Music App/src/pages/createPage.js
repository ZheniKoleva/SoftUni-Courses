import { createTemplate } from "./../templates/createTemplate.js";
import albumService from './../services/albumService.js';
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
         
        await albumService.createAlbum(inputData);       
        cntx.page.redirect('/catalog');

    } catch (error) {
        alert(error.message);
    }
}

export default {
    getView
}