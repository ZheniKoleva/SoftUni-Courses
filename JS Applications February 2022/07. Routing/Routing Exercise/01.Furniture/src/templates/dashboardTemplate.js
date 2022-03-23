import { html } from './../../node_modules/lit-html/lit-html.js';
import { furnitureTemplate } from './commonFurnitureTemplate.js';

export const dashboardTemplate = (furnitures) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Welcome to Furniture System</h1>
        <p>Select furniture from the catalog to view details.</p>
    </div>
</div>
<div class="row space-top">
    ${furnitures.map(furnitureTemplate)}
</div>
`;