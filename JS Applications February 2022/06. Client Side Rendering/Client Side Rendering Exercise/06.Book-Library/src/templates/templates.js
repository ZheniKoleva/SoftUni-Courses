import { html } from './../../../node_modules/lit-html/lit-html.js';

export const mainTemplate = (loadBooksHandler, changeBookHandler) => html`
<button id="loadBooks" @click=${loadBooksHandler}>LOAD ALL BOOKS</button>
    <table>
        <thead>
            <tr>
                <th>Title</th>
                <th>Author</th>
                <th>Action</th>
            </tr>
        </thead>
        <tbody id="table-body" @click=${changeBookHandler}>        
        </tbody>
    </table>
`;

export const allBooksTemplate = (books) => html`
    ${books.map(bookTemplate)}
`;

const bookTemplate = (bookData) => html`
<tr data-id=${bookData._id}>
    <td>${bookData.title}</td>
    <td>${bookData.author}</td>
    <td>
        <button data-id=${bookData._id}>Edit</button>
        <button data-id=${bookData._id}>Delete</button>
    </td>
</tr>
`;


export const addFormTemplate = (addBookHandler) => html`
<form id="add-form" @submit=${addBookHandler}>
    <h3>Add book</h3>
    <label>TITLE</label>
    <input type="text" name="title" placeholder="Title...">
    <label>AUTHOR</label>
    <input type="text" name="author" placeholder="Author...">
    <input type="submit" value="Submit">
</form>
`;

export const editFormTemplate = (bookData, editBookHandler) => html`
<form id="edit-form" @submit=${editBookHandler}>
    <input type="hidden" name="id" .value=${bookData._id}>
    <h3>Edit book</h3>
    <label>TITLE</label>
    <input type="text" name="title" placeholder="Title..." .value=${bookData.title}>
    <label>AUTHOR</label>
    <input type="text" name="author" placeholder="Author..." .value=${bookData.author}>
    <input type="submit" value="Save">
</form>
`;