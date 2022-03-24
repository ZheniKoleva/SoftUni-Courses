import authService from './../services/authService.js';
import furnitureService from "./../services/furnitureService.js";
import { detailsTemplate } from './../templates/detailsTemplate.js';

export async function detailsView(cntx) {
    const binded = deleteFurniture.bind(null, cntx);
    
    try {
        const furniture = await furnitureService.getById(cntx.params.id);
        const isOwner = authService.isLogged() && authService.getUserId() === furniture._ownerId;
        const template = detailsTemplate(furniture, binded, isOwner);
        cntx.renderView(template);
    } catch (error) {
        alert(error.message);
    }   
}

async function deleteFurniture(cntx, e) {
    const confirmForm = confirm('Are you sure you would like to delete this item?');

    if(confirmForm) {
        try {
            await furnitureService.deleteFurniture(cntx.params.id);
            alert('Item deleted successfully!');
            cntx.page.redirect('/dashboard');
        } catch (error) {
            alert(error.message);
        }       
    }   
}