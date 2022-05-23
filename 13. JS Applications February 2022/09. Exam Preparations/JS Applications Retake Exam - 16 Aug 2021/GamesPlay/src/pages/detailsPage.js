import { detailsTemplate } from './../templates/detailsTemplate.js';
import commentService from './../services/commentService.js';
import gameService from './../services/gameService.js';
import validations from './../services/validations.js';

async function getView(cntx) { 
    const bindedDelete = deleteGame.bind(null, cntx); 
    const bindedCreateComment = createComment.bind(null, cntx);
    const gameId = cntx.params.id;
    const isLogged = cntx.user;    

    try { 
        const gameData = gameService.getById(gameId);
        const commentsData = commentService.getByGame(gameId);

        const [game, comments] = await Promise.all([
            gameData,
            commentsData
        ]);

        const isOwner =  isLogged && cntx.token.userId === game._ownerId;

        const formData = {
            game,
            comments,
            isLogged,
            isOwner,
            deleteHandler: bindedDelete,
            commentHandler: bindedCreateComment
        };             

        const template = detailsTemplate(formData);
        cntx.renderView(template);

    } catch (error) {
        alert(error.message);
    }     
}

async function deleteGame(cntx, e) {
    const confirmForm = confirm('Are you sure you would like to delete this item?');

    if(confirmForm) {
        try {
            await gameService.deleteGame(cntx.params.id);            
            cntx.page.redirect('/');
            
        } catch (error) {
            alert(error.message);
        }       
    }   
}

async function createComment(cntx, e) {
    e.preventDefault();

    const gameId = cntx.params.id;
    const form = e.target;
    const formData = new FormData(form);
    const data = Object.fromEntries(formData);

    try {
        validations.validateInputs(data);        

        const commentData = {            
            comment: data.comment,
            gameId: gameId,           
        };

        await commentService.postComment(commentData);
        form.reset();       
        cntx.page.redirect(`/details/${gameId}`);

    } catch (error) {        
        alert(error.message);
    }
}

export default {
    getView
}