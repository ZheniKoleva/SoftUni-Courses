import { html } from './../../node_modules/lit-html/lit-html.js';

export const navbarTemplate = (cntx) => html`
<h1><a class="home" href="/">GamesPlay</a></h1>
<nav>
    <a href="/catalog">All games</a>        
    ${cntx.user 
        ? userTemplate()
        : guestTemplate()
    }
</nav>
`;

const userTemplate = () => html`
<div id="user">
  <a href="/create">Create Game</a>
  <a href="/logout">Logout</a>
<div>
`;

const guestTemplate = () => html`
<div id="guest">
    <a href="/login">Login</a>
    <a href="/register">Register</a>
</div>
`;

