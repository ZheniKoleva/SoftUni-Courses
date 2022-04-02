import { html } from './../../node_modules/lit-html/lit-html.js';
import { bookTemplate } from './bookTemplate.js';

export const myBooksTemplate = (books) => html`
<section id="my-books-page" class="my-books">
<h1>My Books</h1>
${books.length > 0 
    ? html`<ul class="my-books-list"> ${books.map(bookTemplate)} </ul>`
    : html`<p class="no-books">No books in database!</p>`
}
</section>
`;
