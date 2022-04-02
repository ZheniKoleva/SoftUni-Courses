import { html } from './../../node_modules/lit-html/lit-html.js';
import { carTemplate } from './carTemplate.js'; 

export const searchTemplate = (clickHandler, searchResult) => html`
<section id="search-cars">
    <h1>Filter by year</h1>

    <div class="container">
        <input id="search-input" type="text" name="search" placeholder="Enter desired production year">
        <button class="button-list" @click=${clickHandler}>Search</button>
    </div>

    <h2>Results:</h2>
    <div class="listings">
        ${searchResult.length > 0
            ? html`${searchResult.map(carTemplate)}`
            : html`<p class="no-cars"> No matching listings </p>` 
        }       
    </div>
</section> 
`;