import { createTemplate } from "./../templates/createTemplate.js";
import petService from './../services/petService.js';
import validations from '../services/validations.js';

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

        const petData = {
            name: inputData.name,
            breed: inputData.breed,
            age: inputData.age,
            weight: inputData.weight,
            image:inputData.image
        };
         
        await petService.createPet(petData);       
        cntx.page.redirect('/');

    } catch (error) {
        alert(error.message);
    }
}

export default {
    getView
}