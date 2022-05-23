import { searchTemplate } from "./../templates/searchTemplate.js";
import albumService from "../services/albumService.js";

function getView(cntx) {  
    const isLogged = cntx.user;
    const binded = getResults.bind(null, cntx);
    const template = searchTemplate(binded, [], isLogged);
    cntx.renderView(template);
}

async function getResults(cntx, e) {    
    const textToSearch = document.querySelector('#search-input').value;
    const isLogged = cntx.user;

    try { 
        if(textToSearch) {
            const resultAlbums = await albumService.getByCriteria(textToSearch);  
            const binded = getResults.bind(null, cntx);      
            const template = searchTemplate(binded, resultAlbums, isLogged);
            cntx.renderView(template);
        } else {
            throw new Error('Please enter search criteria!');
        }     
         
    } catch (error) {
        alert(error.message);
    }
}

export default {
    getView
}