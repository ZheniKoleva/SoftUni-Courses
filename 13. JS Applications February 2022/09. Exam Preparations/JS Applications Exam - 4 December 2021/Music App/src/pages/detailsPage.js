import { detailsTemplate } from './../templates/detailsTemplate.js';
import albumService from '../services/albumService.js';
import authService from './../services/authService.js';

async function getView(cntx) {
    const binded = deleteAlbum.bind(null, cntx);
    
    try {
        const album = await albumService.getById(cntx.params.id);
        const isOwner = authService.getUserId() === album._ownerId;
        const template = detailsTemplate(album, binded, isOwner);
        cntx.renderView(template);

    } catch (error) {
        alert(error.message);
    }     
}

async function deleteAlbum(cntx, e) {
    const confirmForm = confirm('Are you sure you would like to delete this item?');

    if(confirmForm) {
        try {
            await albumService.deleteAlbum(cntx.params.id);            
            cntx.page.redirect('/catalog');
            
        } catch (error) {
            alert(error.message);
        }       
    }   
}

export default {
    getView
}