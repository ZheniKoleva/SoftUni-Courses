import { detailsTemplate } from './../templates/detailsTemplate.js';
import carService from './../services/carService.js';

async function getView(cntx) {
    const bindedDelete = deleteMeme.bind(null, cntx); 
    const carId = cntx.params.id;

    try {        
        const carData = await carService.getById(carId);
        const isOwner = cntx.user && cntx.token.userId === carData._ownerId;
        const template = detailsTemplate(carData, isOwner, bindedDelete);
        cntx.renderView(template);

    } catch (error) {
        alert(error.message);
    }     
}

async function deleteMeme(cntx, e) {
    const confirmForm = confirm('Are you sure you would like to delete this item?');

    if(confirmForm) {
        try {
            await carService.deleteCar(cntx.params.id);            
            cntx.page.redirect('/all');
            
        } catch (error) {
            alert(error.message);
        }       
    }   
}

export default {
    getView
}