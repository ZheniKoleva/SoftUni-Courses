import { html } from './../../node_modules/lit-html/lit-html.js';

export const navbarTemplate = (cntx) => html`
 <nav>
    <a class="active" href="/">Home</a>
    <a href="/all">All Listings</a>
    <a href="/search">By Year</a>
    ${cntx.user 
        ? userTemplate(cntx) 
        : guestTemplate()
    }   
</nav>
`;

const userTemplate = (cntx) => html`
<div id="profile">
    <a>Welcome ${cntx.token.username}</a>
    <a href="/myCars">My Listings</a>
    <a href="/create">Create Listing</a>
    <a href="/logout">Logout</a>
</div>
`;

const guestTemplate = () => html`
<div id="guest">
    <a href="/login">Login</a>
    <a href="/register">Register</a>
</div>
`;

