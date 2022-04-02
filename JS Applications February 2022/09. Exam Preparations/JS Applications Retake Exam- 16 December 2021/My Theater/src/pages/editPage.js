import { editTemplate } from "./../templates/editTemplate.js"; 
import theaterService from "../services/theaterService.js";
import validations from './../services/validations.js';

async function getView(cntx) {
    const theaterId = cntx.params.id;
    const binded = update.bind(null, cntx);

    try {
        const theaterData = await theaterService.getById(theaterId);
        const template = editTemplate(theaterData, binded);
        cntx.renderView(template);

    } catch (error) {
        alert(error.message);
    }    
}

async function update(cntx, e) {
    e.preventDefault();

    const theaterId = cntx.params.id;
    const form = e.target;
    const formData = new FormData(form);
    const newData = Object.fromEntries(formData);    

    try {
        validations.validateInputs(newData); 
        
        await theaterService.updateTheater(newData, theaterId);        
        cntx.page.redirect(`/details/${theaterId}`);

    } catch (error) {
        alert(error.message);
    }
}

export default {
    getView
}