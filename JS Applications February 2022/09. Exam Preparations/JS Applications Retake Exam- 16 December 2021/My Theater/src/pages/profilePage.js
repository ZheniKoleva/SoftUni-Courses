import { profileTemplate } from "./../templates/profileTemplate.js";
import theaterService from "../services/theaterService.js";
import authService from '../services/authService.js';

async function getView(cntx) {
    try {
        const userEmail = authService.getUserEmail();
        const userId = authService.getUserId();

        const userTheaters = await theaterService.getByOwner(userId);
        const template = profileTemplate(userEmail, userTheaters);
        cntx.renderView(template);
        
    } catch (error) {
        alert(error.message);
    }   
}

export default {
    getView
}