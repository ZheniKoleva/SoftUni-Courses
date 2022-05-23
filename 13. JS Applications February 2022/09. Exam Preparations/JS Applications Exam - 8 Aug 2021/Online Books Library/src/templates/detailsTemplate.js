import { html } from './../../node_modules/lit-html/lit-html.js';

export const detailsTemplate = (formData) => html`
<section id="details-page" class="details">
    <div class="book-information">
        <h3>${formData.book.title}</h3>
        <p class="type">Type: ${formData.book.type}</p>
        <p class="img"><img src=${formData.book.imageUrl}></p>
        <div class="actions">
            ${generateButtons(formData)}
            <div class="likes">
                <img class="hearts" src="/images/heart.png">
                <span id="total-likes">Likes: ${formData.totalLikes}</span>
            </div>            
        </div>
    </div>
    <div class="book-description">
        <h3>Description:</h3>
        <p>${formData.book.description}</p>
    </div>
</section>
`;

function generateButtons(formData) {
    const buttons = [];

    if (formData.isLogged && formData.isOwner) {
        const updateBtns = html`
            <a class="button" href="/edit/${formData.book._id}">Edit</a>
            <a class="button" href="javascript:void(0)" @click=${formData.deleteBook}>Delete</a>
        `;

        buttons.push(updateBtns);
    }

    if (formData.isLogged && !formData.isOwner && !formData.isUserLiked) {
        const likeBtn = html`<a class="button" href="#" @click=${formData.likeBook}>Like</a>`;

        buttons.push(likeBtn);
    }

    return buttons;
}