import { homeTemplate } from "./../templates/homeTemplate.js"; 
import theaterService from "../services/theaterService.js";

async function getView(cntx) {

    try {
        const theaters = await theaterService.getAll();
        const template = homeTemplate(theaters);
        cntx.renderView(template);
        
    } catch (error) {
        alert(error.message);
    }    
}

export default {
    getView
}