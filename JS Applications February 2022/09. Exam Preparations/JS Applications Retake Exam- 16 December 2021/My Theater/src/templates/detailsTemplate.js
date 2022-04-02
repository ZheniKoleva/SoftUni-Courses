import { html } from './../../node_modules/lit-html/lit-html.js';

export const detailsTemplate = (formData) => html`
<section id="detailsPage">
    <div id="detailsBox">
        <div class="detailsInfo">
            <h1>Title: ${formData.theater.title}</h1>
            <div>
                <img src=${formData.theater.imageUrl} /> 
            </div>
        </div>

        <div class="details">
            <h3>Theater Description</h3>
            <p>${formData.theater.description}</p>
            <h4>Date: ${formData.theater.date}</h4>
            <h4>Author: ${formData.theater.author}</h4>
            <div class="buttons">
               ${generateButtons(formData)}
            </div>
            <p class="likes">Likes: ${formData.totalLikes}</p>
        </div>
    </div>
</section>
`;

function generateButtons(formData) {
    const buttons = [];

    if(formData.isLogged && formData.isOwner){
        const updateBtns = html`
        <a class="btn-delete" href="javascript:void(0)" @click=${formData.deleteTheater}>Delete</a>
        <a class="btn-edit" href="/edit/${formData.theater._id}">Edit</a>`;

        buttons.push(updateBtns);
    }

    if(formData.isLogged && !formData.isOwner && !formData.isUserLiked) {
        const likeBtn = html`<a class="btn-like" href="#" @click=${formData.likeTheater}>Like</a>`;

        buttons.push(likeBtn);
    }
   
    return buttons;
}