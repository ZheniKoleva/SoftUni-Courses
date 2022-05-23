import { html } from './../../node_modules/lit-html/lit-html.js';

export const navbarTemplate = (cntx) => html`
${cntx.user 
    ? userTemplate(cntx) 
    : guestTemplate()
}
`;

const userTemplate = (cntx) => html`
<a href="/all">All Memes</a>
<div class="user">
<a href="/create">Create Meme</a>
<div class="profile">
    <span>Welcome, ${cntx.token.email}</span>
    <a href="/profile">My Profile</a>
    <a href="/logout">Logout</a>
</div>
`;

const guestTemplate = () => html`
<a class="active" href="/">Home Page</a>
<a href="/all">All Memes</a>
<div class="guest">
<div class="profile">
    <a href="login">Login</a>
    <a href="/register">Register</a>
</div>
`;

