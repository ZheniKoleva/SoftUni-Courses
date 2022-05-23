import { html, nothing } from './../../node_modules/lit-html/lit-html.js';

export const detailsTemplate = (memeData, isOwner, deleteHandler) => html`
<section id="meme-details">
<h1>Meme Title: ${memeData.title}</h1>
<div class="meme-details">
    <div class="meme-img">
        <img alt="meme-alt" src=${memeData.imageUrl}>
    </div> 
    <div class="meme-description">
        <h2>Meme Description</h2>
        <p>${memeData.description}</p>
        ${isOwner
            ? html`
                <a class="button warning" href="/edit/${memeData._id}">Edit</a>
                <button class="button danger" @click=${deleteHandler}>Delete</button>`
            : nothing
        }        
    </div>
</div>
</section>
`; 