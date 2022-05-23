import { dashboardTemplate } from "./../templates/dashboardTemplate.js"; 
import petService from "../services/petService.js";

async function getView(cntx) {

    try {
        const books = await petService.getAll();
        const template = dashboardTemplate(books);
        cntx.renderView(template);
    } catch (error) {
        alert(error.message);
    }    
}

export default {
    getView
}