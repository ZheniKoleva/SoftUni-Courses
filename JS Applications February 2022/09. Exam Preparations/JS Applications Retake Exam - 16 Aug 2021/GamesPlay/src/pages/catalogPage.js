import { catalogTemplate } from "./../templates/catalogTemplate.js";
import gameService from './../services/gameService.js';

async function getView(cntx) {

    try {  
        const games = await gameService.getAll();
        const template = catalogTemplate(games);
        cntx.renderView(template);
        
    } catch (error) {
        alert(error.message);
    }    
}

export default {
    getView
}