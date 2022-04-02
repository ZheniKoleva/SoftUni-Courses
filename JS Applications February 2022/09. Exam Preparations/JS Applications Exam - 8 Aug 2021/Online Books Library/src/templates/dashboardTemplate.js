import { html } from './../../node_modules/lit-html/lit-html.js';
import { bookTemplate } from './bookTemplate.js';

export const dashboardTemplate = (books) => html`
<section id="dashboard-page" class="dashboard">
<h1>Dashboard</h1>
${books.length > 0 
    ? html`<ul class="other-books-list"> ${books.map(bookTemplate)} </ul>`
    : html`<p class="no-books">No books in database!</p>`
}   
</section>
`;