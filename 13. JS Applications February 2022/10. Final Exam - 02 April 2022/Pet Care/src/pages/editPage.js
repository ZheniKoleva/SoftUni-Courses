import { editTemplate } from "./../templates/editTemplate.js"; 
import petService from "../services/petService.js";
import validations from './../services/validations.js';

async function getView(cntx) {
    const petId = cntx.params.id;
    const binded = update.bind(null, cntx);

    try {
        const petData = await petService.getById(petId);
        const template = editTemplate(petData, binded);
        cntx.renderView(template);
    } catch (error) {
        alert(error.message);
    }    
}

async function update(cntx, e) {
    e.preventDefault();

    const petId = cntx.params.id;
    const form = e.target;
    const formData = new FormData(form);
    const newData = Object.fromEntries(formData);    

    try {
        validations.validateInputs(newData);
        
        const petData = {
            name: newData.name,
            breed: newData.breed,
            age: newData.age,
            weight: newData.weight,
            image:newData.image
        };
        
        await petService.updatePet(petData, petId);        
        cntx.page.redirect(`/details/${petId}`);

    } catch (error) {
        alert(error.message);
    }
}

export default {
    getView
}