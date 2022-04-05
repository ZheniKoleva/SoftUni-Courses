import { html } from './../../node_modules/lit-html/lit-html.js';

export const navbarTemplate = (cntx) => html`
 <nav>
    <section class="logo">
        <img src="./images/logo.png" alt="logo">
    </section>
    <ul>      
        <li><a href="/">Home</a></li>
        <li><a href="/dashboard">Dashboard</a></li>
        ${cntx.user 
            ? userTemplate() 
            : guestTemplate()
        }       
    </ul>
</nav>
`;

const userTemplate = () => html`
<li><a href="/create">Create Postcard</a></li>
<li><a href="/logout">Logout</a></li>
`;

const guestTemplate = () => html`
<li><a href="/login">Login</a></li>
<li><a href="/register">Register</a></li>
`;