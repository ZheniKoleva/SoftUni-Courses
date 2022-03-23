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

    formInfo.checker = {};

    const form = e.target;
    const formData = new FormData(form);
    const furnitureData = Object.fromEntries(formData);

    try {
        formInfo.checker.make = validations.validateMake(furnitureData.make);
        formInfo.checker.model = validations.validateModel(furnitureData.model);
        formInfo.checker.year = validations.validateYear(furnitureData.year);
        formInfo.checker.description = validations.validateDescription(furnitureData.description);
        formInfo.checker.price = validations.validatePrice(furnitureData.price);
        formInfo.checker.img = validations.validateImage(furnitureData.img);       

        if (Object.values(formInfo.checker).some(x => !x)) {
            const template = createTemplate(formInfo);
            return cntx.renderView(template);
        }
                
        await furnitureService.createFurniture(furnitureData);
        alert('Item added to dashboard successfully!');
        cntx.page.redirect('/dashboard');

    } catch (error) {
        alert(error.message);
    }
}