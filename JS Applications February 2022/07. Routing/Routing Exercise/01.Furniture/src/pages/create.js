import validations from './../services/validations.js';
import furnitureService from "../services/furnitureService.js";
import { createTemplate } from "../templates/createTemplate.js";

let formInfo = undefined;

export async function createView(cntx) {
    const binded = create.bind(null, cntx);
    const checker = {
        make: false,
        model: false,
        year: false,
        description: false,
        price: false,
        img: false,
    };

    formInfo = {
        create: binded,
        checker
    };

    const template = createTemplate(formInfo);
    cntx.renderView(template);
}

async function create(cntx, e) {
    e.preventDefault();

    const form = e.target;
    const formData = new FormData(form);
    const furnitureData = Object.fromEntries(formData);

    formInfo.checker = {};

    try {
        validations.validateFurnitureData(formInfo.checker, furnitureData); 
        const template = createTemplate(formInfo);
        cntx.renderView(template);

        if (Object.values(formInfo.checker).some(x => !x)) {
            alert('Please, fill the required fields!');  
            return;
        }       
                
        await furnitureService.createFurniture(furnitureData);
        alert('Item added to dashboard successfully!');
        cntx.page.redirect('/dashboard');

    } catch (error) {
        alert(error.message);
    }
}