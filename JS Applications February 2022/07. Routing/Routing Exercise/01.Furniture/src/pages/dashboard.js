import furnitureService from "./../services/furnitureService.js";
import { dashboardTemplate } from './../templates/dashboardTemplate.js'

export async function dashboardView(cntx) {
    try {
        const furnitures = await furnitureService.getAll();
        const template = dashboardTemplate(furnitures);
        cntx.renderView(template);
    } catch (error) {
        alert(error.message);
    }    
}