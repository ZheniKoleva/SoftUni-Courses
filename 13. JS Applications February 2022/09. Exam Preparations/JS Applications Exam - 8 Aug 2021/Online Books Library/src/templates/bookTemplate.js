import { html } from './../../node_modules/lit-html/lit-html.js';

export const bookTemplate = (bookData) => html`
<li class="otherBooks">
    <h3>${bookData.title}</h3>
    <p>Type: ${bookData.type}</p>
    <p class="img"><img src=${bookData.imageUrl}></p>
    <a class="button" href="/details/${bookData._id}">Details</a>
</li>
`;