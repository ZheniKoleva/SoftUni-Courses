import { detailsTemplate } from './../templates/detailsTemplate.js';
import theaterService from '../services/theaterService.js';
import likeService from '../services/likeService.js';
import authService from './../services/authService.js';

async function getView(cntx) {
    const bindedDelete = deleteTheater.bind(null, cntx);
    const bindedLike = likeTheater.bind(null, cntx);
    const theaterId = cntx.params.id;

    try {
        const isLogged = cntx.user;  
        const userId = isLogged ? authService.getUserId() : null;
        const isOwner = isLogged && userId === theater._ownerId; 

        const theaterRequest = theaterService.getById(cntx.params.id);
        const totalLikesRequest = likeService.getByTheater(cntx.params.id);       

        const [theater, totalLikes, isUserLiked] = await Promise.all([
            theaterRequest, 
            totalLikesRequest,
            isLogged ? likeService.getByUser(theaterId, userId) : 0          
        ]);

        const formData = {
            deleteTheater: bindedDelete,
            likeTheater: bindedLike,
            isLogged,
            userId,
            isOwner,
            theater,
            totalLikes,
            isUserLiked,
        };

        const template = detailsTemplate(formData);
        cntx.renderView(template);

    } catch (error) {
        alert(error.message);
    }     
}

async function deleteTheater(cntx, e) {
    const confirmForm = confirm('Are you sure you would like to delete this item?');

    if(confirmForm) {
        try {
            await theaterService.deleteTheater(cntx.params.id);            
            cntx.page.redirect('/profile');
            
        } catch (error) {
            alert(error.message);
        }       
    }   
}

async function likeTheater(cntx, e) {
    
    try {
        const data = { theaterId: cntx.params.id }
        await likeService.likeTheater(data);
        cntx.page.redirect(`/details/${cntx.params.id}`);

    } catch (error) {
        alert(error.message);
    }
}

export default {
    getView
}