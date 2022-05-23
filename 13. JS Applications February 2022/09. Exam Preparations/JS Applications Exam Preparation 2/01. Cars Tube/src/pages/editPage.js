import { editTemplate } from './../templates/editTemplate.js'; 
import carService from './../services/carService.js';
import validations from './../services/validations.js';

async function getView(cntx) {
    const carId = cntx.params.id;
    const binded = update.bind(null, cntx);

    try {
        const carData = await carService.getById(carId);
        const template = editTemplate(carData, binded);
        cntx.renderView(template);
        
    } catch (error) {
        alert(error.message);
    }    
}

async function update(cntx, e) {
    e.preventDefault();

    const carId = cntx.params.id;
    const form = e.target;
    const formData = new FormData(form);
    const newData = Object.fromEntries(formData);    

    try {
        validations.validateInputs(newData); 
        validations.validateYearAndPrice(newData.year, newData.price); 

        const carData = {
            brand: newData.brand,
            model: newData.model,
            description: newData.description,
            year: Number(newData.year),
            imageUrl: newData.imageUrl,
            price: Number(newData.price)
        };

        await carService.updateCar(carData, carId); 
        cntx.page.redirect(`/details/${carId}`);

    } catch (error) {
        alert(error.message);
    }
}

export default {
    getView
}