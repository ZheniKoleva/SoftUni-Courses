import { html } from './../../node_modules/lit-html/lit-html.js';
import { ifDefined } from './../../node_modules/lit-html/directives/if-defined.js';


export const navbarTemplate = (cntx, isLogged) => html`
<h1><a href="/">Furniture Store</a></h1>
<nav>
    <a id="catalogLink" href="/dashboard" class=${ifDefined(cntx.pathname.startsWith('/dashboard') ? 'active' : undefined)}>Dashboard</a>
${isLogged 
? html`
    <div id="user">
        <a id="createLink" href="/create" class=${ifDefined(cntx.pathname.startsWith('/create') ? 'active' : undefined)}>Create Furniture</a>
        <a id="profileLink" href="/my-furniture" class=${ifDefined(cntx.pathname.startsWith('/my-furniture') ? 'active' : undefined)}>My Publications</a>
        <a id="logoutBtn" href="/logout" >Logout</a>
    </div>`
: html`
    <div id="guest">
        <a id="loginLink" href="/login" class=${ifDefined(cntx.pathname.startsWith('/login') ? 'active' : undefined)}>Login</a>
        <a id="registerLink" href="/register" class=${ifDefined(cntx.pathname.startsWith('/register') ? 'active' : undefined)}>Register</a>
    </div>`}
</nav>`;