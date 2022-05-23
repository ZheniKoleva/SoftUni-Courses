import { myBooksTemplate } from "../templates/myBooksTemplate.js";
import libraryService from "../services/libraryService.js";

async function getView(cntx) {
    try {        
        const userId = cntx.token.userId;
        const userBooks = await libraryService.getByOwner(userId);
        const template = myBooksTemplate(userBooks);
        cntx.renderView(template);
        
    } catch (error) {
        alert(error.message);
    }   
}

export default {
    getView
}