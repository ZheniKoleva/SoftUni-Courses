import { editTemplate } from "./../templates/editTemplate.js"; 
import gameService from './../services/gameService.js';
import validations from './../services/validations.js';

async function getView(cntx) {
    const gameId = cntx.params.id;
    const binded = update.bind(null, cntx);

    try {
        const gameData = await gameService.getById(gameId);
        const template = editTemplate(gameData, binded);
        cntx.renderView(template);

    } catch (error) {
        alert(error.message);
    }    
}

async function update(cntx, e) {
    e.preventDefault();

    const gameId = cntx.params.id;
    const form = e.target;
    const formData = new FormData(form);
    const newData = Object.fromEntries(formData);    

    try {
        validations.validateInputs(newData); 
        
        await gameService.updateGame(newData, gameId);        
        cntx.page.redirect(`/details/${gameId}`);

    } catch (error) {
        alert(error.message);
    }
}

export default {
    getView
}