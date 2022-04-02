import { catalogTemplate } from "./../templates/catalogTemplate.js";
import albumService from './../services/albumService.js';

async function getView(cntx) {
    try {
        const albums = await albumService.getAll();
        const isLogged = cntx.user;
        const template = catalogTemplate(albums, isLogged);
        cntx.renderView(template);

    } catch (error) {
        alert(error.message);
    }     
}

export default {
    getView
}
