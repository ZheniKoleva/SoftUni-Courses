import authService from './../services/authService.js';
import furnitureService from "./../services/furnitureService.js";
import { myFurnitureTemplate } from './../templates/myFurnitureTemplate.js'

export async function myFurnitureView(cntx) {
    const userId = authService.getUserId();
    
    try {
        const furnitures = await furnitureService.getOwnFurniture(userId);
        const template = myFurnitureTemplate(furnitures);
        cntx.renderView(template);

    } catch (error) {
        alert(error.message);
    }    
}