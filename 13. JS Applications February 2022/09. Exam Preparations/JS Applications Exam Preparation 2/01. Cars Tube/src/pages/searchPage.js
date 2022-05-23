import { searchTemplate } from './../templates/searchTemplate.js';
import carService from './../services/carService.js';

async function getView(cntx) {
    const binded = getSearchResults.bind(null, cntx);
    const template = searchTemplate(binded, []);
    cntx.renderView(template, []);   
}

async function getSearchResults(cntx, e) {

    const parent = e.target.parentElement;
    const searchValue = parent.querySelector('#search-input').value;   

    try {       
        if(searchValue.trim() && Number(searchValue) > 0) {
            const searchResult = await carService.getByYear(searchValue);  
            const binded = getSearchResults.bind(null, cntx);      
            const template = searchTemplate(binded, searchResult);
            cntx.renderView(template, searchResult);

        } else {
            throw new Error('Please enter an year!');
        }  

    } catch (error) {
        alert(error.message);
    }
}

export default {
    getView
}