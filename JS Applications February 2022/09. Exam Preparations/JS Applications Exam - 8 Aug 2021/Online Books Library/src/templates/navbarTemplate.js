import { html } from './../../node_modules/lit-html/lit-html.js';

export const navbarTemplate = (cntx) => html`
<nav class="navbar">
    <section class="navbar-dashboard">
        <a href="/">Dashboard</a>
        ${cntx.user 
            ? userTemplate(cntx.token) 
            : guestTemplate()}       
    </section>
</nav>
`;

const userTemplate = (token) => html`
<div id="user">
    <span>Welcome, ${token.email}</span>
    <a class="button" href="/myBooks">My Books</a>
    <a class="button" href="/add">Add Book</a>
    <a class="button" href="/logout">Logout</a>
</div>
`;

const guestTemplate = () => html`
<div id="guest">
    <a class="button" href="/login">Login</a>
    <a class="button" href="/register">Register</a>
</div>
`;