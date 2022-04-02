import { allMemesTemplate } from "./../templates/allMemesTemplate.js";
import memeService from './../services/memeService.js';

async function getView(cntx) {

    try {  
        const memes = await memeService.getAll();
        const template = allMemesTemplate(memes);
        cntx.renderView(template);
        
    } catch (error) {
        alert(error.message);
    }    
}

export default {
    getView
}