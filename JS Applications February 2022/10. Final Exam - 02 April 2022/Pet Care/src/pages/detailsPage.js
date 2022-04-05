import { detailsTemplate } from './../templates/detailsTemplate.js';
import petService from '../services/petService.js';
import donateService from '../services/donateService.js';

async function getView(cntx) {
    const bindedDelete = deletePet.bind(null, cntx);
    const bindedDonate = donate.bind(null, cntx);
    const petId = cntx.params.id;    

    try {
        const isLogged = cntx.user;
        const userId = isLogged ? cntx.token.userId : null;        

        const petRequest = petService.getById(petId);
        const donationsRequest = donateService.getByPetId(petId);       

        const [pet, donations, isUserDonate] = await Promise.all([
            petRequest, 
            donationsRequest,
            isLogged ? donateService.getByUser(petId, userId) : 0          
        ]);

        const isOwner = isLogged && userId == pet._ownerId;

        const formData = {
            deletePet: bindedDelete,
            donate: bindedDonate,
            isLogged,
            isOwner,
            pet,
            donations: donations * 100,
            isUserDonate
        };       
    
        const template = detailsTemplate(formData);
        cntx.renderView(template);

    } catch (error) {
        alert(error.message);
    }     
}

async function deletePet(cntx, e) {
    const confirmForm = confirm('Are you sure you would like to delete this item?');

    if(confirmForm) {
        try {
            await petService.deletePet(cntx.params.id);            
            cntx.page.redirect('/');
            
        } catch (error) {
            alert(error.message);
        }       
    }   
}

async function donate(cntx, e) {   
    const petId = cntx.params.id;
    
    try {        
        await donateService.donate({ petId: petId });
        cntx.page.redirect(`/details/${petId}`);

    } catch (error) {
        alert(error.message);
    }
}

export default {
    getView
}