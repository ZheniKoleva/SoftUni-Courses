import { detailsTemplate } from './../templates/detailsTemplate.js';
import libraryService from '../services/libraryService.js';
import likeService from '../services/likeService.js';

async function getView(cntx) {
    const bindedDelete = deleteBook.bind(null, cntx);
    const bindedLike = likeBook.bind(null, cntx);
    const bookId = cntx.params.id;  

    try {
        const isLogged = cntx.user; 
        const userId = isLogged ? cntx.token.userId : null;      
        const isOwner = isLogged && userId === book._ownerId;

        const bookRequest = libraryService.getById(bookId);
        const totalLikesRequest = likeService.getByBook(bookId);       

        const [book, totalLikes, isUserLiked] = await Promise.all([
            bookRequest, 
            totalLikesRequest,
            isLogged ? likeService.getByUser(bookId, userId) : 0
        ]);

        const formData = {
            deleteBook: bindedDelete,
            likeBook: bindedLike,
            isLogged,
            userId,
            book,
            totalLikes,
            isUserLiked,
            isOwner
        };      
       
        const template = detailsTemplate(formData);
        cntx.renderView(template);

    } catch (error) {
        alert(error.message);
    }     
}

async function deleteBook(cntx, e) {
    const confirmForm = confirm('Are you sure you would like to delete this item?');

    if(confirmForm) {
        try {
            await libraryService.deleteBook(cntx.params.id);            
            cntx.page.redirect('/');
            
        } catch (error) {
            alert(error.message);
        }       
    }   
}

async function likeBook(cntx, e) {
    const bookId = cntx.params.id;
    
    try {        
        await likeService.likeBook({ bookId });
        cntx.page.redirect(`/details/${bookId}`);

    } catch (error) {
        alert(error.message);
    }
}

export default {
    getView
}