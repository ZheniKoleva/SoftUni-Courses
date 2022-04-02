import { homeTemplate } from "./../templates/homeTemplate.js"; 
import gameService from './../services/gameService.js';

async function getView(cntx) {

    try {  
        const latestGames = await gameService.getLatest();    
        const template = homeTemplate(latestGames);
        cntx.renderView(template);
        
    } catch (error) {
        alert(error.message);
    }    
}

export default {
    getView
}