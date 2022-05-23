import { createTemplate } from "./../templates/createTemplate.js";
import gameService from './../services/gameService.js';
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
         
        await gameService.createGame(inputData);       
        cntx.page.redirect('/all');

    } catch (error) {
        alert(error.message);
    }
}

export default {
    getView
}