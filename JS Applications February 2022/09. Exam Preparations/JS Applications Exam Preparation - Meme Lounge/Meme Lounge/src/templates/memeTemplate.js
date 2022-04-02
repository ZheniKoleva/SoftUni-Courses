import { html } from './../../node_modules/lit-html/lit-html.js';

export const memeTemplate = (memeData) => html`
<div class="meme">
    <div class="card">
        <div class="info">
            <p class="meme-title">${memeData.title}</p>
            <img class="meme-image" alt="meme-img" src=${memeData.imageUrl}>
        </div>
        <div id="data-buttons">
            <a class="button" href="/details/${memeData._id}">Details</a>
        </div>
    </div>
</div>
`;
