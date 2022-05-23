import { homeTemplate } from "./../templates/homeTemplate.js"; 
import memeService from './../services/memeService.js';

async function getView(cntx) {
    const template = homeTemplate(cntx.user);
    cntx.renderView(template)    
}

export default {
    getView
}