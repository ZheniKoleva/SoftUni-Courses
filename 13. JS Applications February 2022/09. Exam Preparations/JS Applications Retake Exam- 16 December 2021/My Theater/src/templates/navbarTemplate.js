import { html } from './../../node_modules/lit-html/lit-html.js';

export const navbarTemplate = (user) => html`
<nav>
    <a href="/">Theater</a>
    <ul>
        ${user 
            ? userTemplate() 
            : guestTemplate()
        }
    </ul>
</nav>
`;

const userTemplate = () => html`
    <li><a href="/profile">Profile</a></li>
    <li><a href="/create">Create Event</a></li>
    <li><a href="/logout">Logout</a></li>
`;

const guestTemplate = () => html`
    <li><a href="/login">Login</a></li>
    <li><a href="/register">Register</a></li>
`;