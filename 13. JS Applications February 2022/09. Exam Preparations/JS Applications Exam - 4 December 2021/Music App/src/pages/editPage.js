import { editTemplate } from "./../templates/editTemplate.js"; 
import albumService from "../services/albumService.js";
import validations from './../services/validations.js';

async function getView(cntx) {
    const albumId = cntx.params.id;
    const binded = update.bind(null, cntx);

    try {
        const albumData = await albumService.getById(albumId);
        const template = editTemplate(albumData, binded);
        cntx.renderView(template);
    } catch (error) {
        alert(error.message);
    }    
}

async function update(cntx, e) {
    e.preventDefault();

    const albumId = cntx.params.id;
    const form = e.target;
    const formData = new FormData(form);
    const newData = Object.fromEntries(formData);    

    try {
        validations.validateInputs(newData); 
        await albumService.updateAlbum(newData, albumId);        
        cntx.page.redirect(`/details/${albumId}`);

    } catch (error) {
        alert(error.message);
    }
}

export default {
    getView
}