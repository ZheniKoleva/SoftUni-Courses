import { profileTemplate } from "./../templates/profileTemplate.js";
import memeService from "../services/memeService.js";

async function getView(cntx) {
    try {        
        const userMemes = await memeService.getByOwner(cntx.token.userId);
        const template = profileTemplate(cntx.token, userMemes);
        cntx.renderView(template);
        
    } catch (error) {
        alert(error.message);
    }   
}

export default {
    getView
}