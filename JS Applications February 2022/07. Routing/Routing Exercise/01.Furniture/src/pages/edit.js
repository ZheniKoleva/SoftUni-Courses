import validations from './../services/validations.js';
import furnitureService from "./../services/furnitureService.js";
import { editTemplate } from './../templates/editTemplate.js';

let formInfo = undefined;

export async function editView(cntx) {
    const binded = update.bind(null, cntx);

    const checker = {
        make: true,
        model: true,
        year: true,
        description: true,
        price: true,
        img: true,
    };

    try {
        const furniture = await furnitureService.getById(cntx.params.id);

        formInfo = {
            furniture,
            update: binded,
            checker
        };

        const template = editTemplate(formInfo);
        cntx.renderView(template);
    } catch (error) {
        alert(error.message);
    }

}

async function update(cntx, e) {
    e.preventDefault();

    const form = e.target;
    const formData = new FormData(form);
    const furnitureData = Object.fromEntries(formData);

    formInfo.checker = {};
    formInfo.furniture = furnitureData;

    try {
        validations.validateFurnitureData(formInfo.checker, furnitureData);
        const template = editTemplate(formInfo);
        cntx.renderView(template);

        if (Object.values(formInfo.checker).some(x => !x)) {
            alert('Please, fill the required fields!');
            return;
        }

        await furnitureService.updateFurniture(furnitureData, cntx.params.id);
        alert('Item updated successfully!');
        cntx.page.redirect(`/details/${cntx.params.id}`);

    } catch (error) {
        alert(error.message);
    }
}