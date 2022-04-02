import { html, nothing } from './../../node_modules/lit-html/lit-html.js';

export const detailsTemplate = (carData, isOwner, deleteHandler) => html`
<section id="listing-details">
    <h1>Details</h1>
    <div class="details-info">
        <img src=${carData.imageUrl}>
        <hr>
        <ul class="listing-props">
            <li><span>Brand:</span>${carData.brand}</li>
            <li><span>Model:</span>${carData.model}</li>
            <li><span>Year:</span>${carData.year}</li>
            <li><span>Price:</span>${carData.price}$</li>
        </ul>

        <p class="description-para">${carData.description}</p>
        ${getButtons(isOwner, carData._id, deleteHandler)}
    </div>
</section>
`; 

function getButtons(isOwner, carId, deleteHandler) {
    let buttons = nothing;

    if(isOwner) {
        buttons = html`
        <div class="listings-buttons">
            <a href="/edit/${carId}" class="button-list">Edit</a>
            <a href="javascript:void(0)" class="button-list" @click=${deleteHandler}>Delete</a>
        </div>
        `;
    }

    return buttons;
}