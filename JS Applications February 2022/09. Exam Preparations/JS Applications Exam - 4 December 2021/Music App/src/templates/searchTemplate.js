import { html } from './../../node_modules/lit-html/lit-html.js';
import { albumTemplate } from './albumTemplate.js';

export const searchTemplate = (clickHandler, albums, isLogged) => html`
<section id="searchPage">
    <h1>Search by Name</h1>

    <div class="search">
        <input id="search-input" type="text" name="search" placeholder="Enter desired albums's name">
        <button @click=${clickHandler} class="button-list">Search</button>
    </div>

    <h2>Results:</h2> 
    <div class="search-result"> 
        ${albums.length > 0
            ? html`${albums.map(x => albumTemplate(x, isLogged))}`
            : html`<p class="no-result">No result.</p>`
        }
    </div>        
</section>
`;