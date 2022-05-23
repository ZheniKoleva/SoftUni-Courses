import { detailsTemplate } from './../templates/detailsTemplate.js';
import memeService from './../services/memeService.js';
import authService from './../services/authService.js';

async function getView(cntx) {
    const bindedDelete = deleteMeme.bind(null, cntx); 

    try {        
        const memeData = await memeService.getById(cntx.params.id);
        const isOwner = cntx.user && authService.getUserId() === memeData._ownerId;
        const template = detailsTemplate(memeData, isOwner, bindedDelete);
        cntx.renderView(template);

    } catch (error) {
        alert(error.message);
    }     
}

async function deleteMeme(cntx, e) {
    const confirmForm = confirm('Are you sure you would like to delete this item?');

    if(confirmForm) {
        try {
            await memeService.deleteMeme(cntx.params.id);            
            cntx.page.redirect('/all');
            
        } catch (error) {
            alert(error.message);
        }       
    }   
}

export default {
    getView
}