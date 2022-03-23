import validations from './../services/validations.js';
import furnitureService from "./../services/furnitureService.js";
import { editTemplate } from './../templates/editTemplate.js';

let formInfo = undefined;

export async function editView(cntx) {
    const furniture = await furnitureService.getById(cntx.params.id);    
    const binded = update.bind(null, cntx);

    const checker = {
        make: true,
        model: true,
        year: true,
        description: true,
        price: true,
        img: true,
    };

    formInfo = {
        furniture,
        update: binded,
        checker
    };

    const template = editTemplate(formInfo);
    cntx.renderView(template);
}

async function update(cntx, e) {
    e.preventDefault();

    const form = e.target;
    const formData = new FormData(form);
    const furnitureData = Object.fromEntries(formData);
    
    formInfo.checker = {};
    formInfo.furniture = furnitureData;

    try {
        formInfo.checker.make = validations.validateMake(furnitureData.make);
        formInfo.checker.model = validations.validateModel(furnitureData.model);
        formInfo.checker.year = validations.validateYear(furnitureData.year);
        formInfo.checker.description = validations.validateDescription(furnitureData.description);
        formInfo.checker.price = validations.validatePrice(furnitureData.price);
        formInfo.checker.img = validations.validateImage(furnitureData.img);
        
        if (Object.values(formInfo.checker).some(x => !x)) {
            const template = editTemplate(formInfo);
            return cntx.renderView(template);
        }
                
        await furnitureService.updateFurniture(furnitureData, cntx.params.id);
        alert('Item updated successfully!');
        cntx.page.redirect(`/details/${cntx.params.id}`);

    } catch (error) {
        alert(error.message);
    }
}