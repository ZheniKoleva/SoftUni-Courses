import { html } from './../../node_modules/lit-html/lit-html.js';
import { furnitureTemplate } from './commonFurnitureTemplate.js';

export const myFurnitureTemplate = (furnitures) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>My Furniture</h1>
        <p>This is a list of your publications.</p>
    </div>
</div>
<div class="row space-top">
    ${furnitures.length > 0
        ? furnitures.map(furnitureTemplate)
        : html`<h2>There is no items in the list yet!</h2>`
    }
</div>
`; 