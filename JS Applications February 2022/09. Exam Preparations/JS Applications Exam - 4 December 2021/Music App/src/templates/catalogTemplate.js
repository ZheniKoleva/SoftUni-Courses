import { html } from './../../node_modules/lit-html/lit-html.js';
import { albumTemplate } from './albumTemplate.js';

export const catalogTemplate = (albums, isLogged) => html`
<section id="catalogPage">
    <h1>All Albums</h1>
    ${albums.length > 0 
        ? albums.map(x => albumTemplate(x, isLogged))
        : html`<p>No Albums in Catalog!</p>`
    }   
</section>
`;