import { html, nothing } from './../../node_modules/lit-html/lit-html.js';

export const detailsTemplate = (formData) => html`
<section id="game-details">
    <h1>Game Details</h1>
    <div class="info-section">

        <div class="game-header">
            <img class="game-img" src=${formData.game.imageUrl} />
            <h1>${formData.game.title}</h1>
            <span class="levels">MaxLevel: ${formData.game.maxLevel}</span>
            <p class="type">${formData.game.category}</p>
        </div>

        <p class="text">${formData.game.summary}</p>  

        ${allCommentsTemplate(formData.comments)}
        ${getButtons(formData.isOwner,formData.game._id, formData.deleteHandler)} 

    </div>

    ${getAddCommentForm(formData.isLogged, formData.isOwner, formData.commentHandler)}
`; 

const allCommentsTemplate = (comments) => html`
<div class="details-comments">
    <h2>Comments:</h2>
    ${comments.length > 0 
        ? html`<ul>${comments.map(commentTemplate)}</ul>`
        : html`<p class="no-comment">No comments.</p>`   
    }    
</div>
`;

const commentTemplate = (commentData) => html`
<li class="comment">
    <p>Content: ${commentData.comment}</p>
</li>
`;

function getButtons (isOwner, gameId, deleteHandler) {
    let buttons = nothing;
    
    if(isOwner) {
        buttons = html`
        <div class="buttons">
            <a href="/edit/${gameId}" class="button">Edit</a>
            <a href="javascript:void(0)" class="button" @click=${deleteHandler}>Delete</a>
        </div>        
        `;
    }

    return buttons;
}  

function getAddCommentForm(isLogged, isOwner, submitHandler) {
    let form = nothing;

    if(isLogged && !isOwner) {
        form = html`
        <article class="create-comment">
            <label>Add new comment:</label>
            <form class="form" @submit=${submitHandler}>
            <textarea name="comment" placeholder="Comment......"></textarea>
            <input class="btn submit" type="submit" value="Add Comment">
            </form>
        </article> 
        `;
    }
    
    return form;
}
