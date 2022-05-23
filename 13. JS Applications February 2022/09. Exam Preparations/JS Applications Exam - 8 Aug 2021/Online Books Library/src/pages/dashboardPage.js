import { dashboardTemplate } from "./../templates/dashboardTemplate.js"; 
import libraryService from "../services/libraryService.js";

async function getView(cntx) {

    try {
        const books = await libraryService.getAll();
        const template = dashboardTemplate(books);
        cntx.renderView(template);
        
    } catch (error) {
        alert(error.message);
    }    
}

export default {
    getView
}