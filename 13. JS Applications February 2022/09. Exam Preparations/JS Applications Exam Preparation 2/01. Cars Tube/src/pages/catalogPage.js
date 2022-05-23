import { allCarsTemplate } from './../templates/catalogTemplate.js';
import carService from './../services/carService.js';

async function getView(cntx) {

    try {  
        const cars = await carService.getAll();
        const template = allCarsTemplate(cars);
        cntx.renderView(template);
        
    } catch (error) {
        alert(error.message);
    }    
}

export default {
    getView
}