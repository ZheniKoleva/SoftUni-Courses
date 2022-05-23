import { html } from './../../node_modules/lit-html/lit-html.js';

export const carTemplate = (carData) => html`
<div class="listing">
    <div class="preview">
        <img src=${carData.imageUrl}>
    </div>
    <h2>${carData.brand} ${carData.model}</h2>
    <div class="info">
        <div class="data-info">
            <h3>Year: ${carData.year}</h3>
            <h3>Price: ${carData.price} $</h3>
        </div>
        <div class="data-buttons">
            <a href="/details/${carData._id}" class="button-carDetails">Details</a>
        </div>
    </div>
</div>
`;