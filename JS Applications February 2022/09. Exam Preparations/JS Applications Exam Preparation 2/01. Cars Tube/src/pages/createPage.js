import { createTemplate } from './../templates/createTemplate.js';
import carService from './../services/carService.js';
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
        validations.validateYearAndPrice(inputData.year, inputData.price);

        const carData = {
            brand: inputData.brand,
            model: inputData.model,
            description: inputData.description,
            year: Number(inputData.year),
            imageUrl: inputData.imageUrl,
            price: Number(inputData.price)
        };

        await carService.createCar(carData);
        cntx.page.redirect('/all');

    } catch (error) {
        alert(error.message);
    }
}

export default {
    getView
}