import { carsTemplate } from './../templates/myCarsTemplate.js';
import carService from './../services/carService.js';

async function getView(cntx) {
    const userId = cntx.token.userId;

    try {        
        const userCars = await carService.getByOwner(userId);
        const template = carsTemplate(userCars);
        cntx.renderView(template);
        
    } catch (error) {
        alert(error.message);
    }   
}

export default {
    getView
}