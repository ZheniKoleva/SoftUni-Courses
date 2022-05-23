import { contacts } from './contacts.js';
import { html, render } from '../node_modules/lit-html/lit-html.js';

const template = (contactData, toggleDetails) => html`
<div class="contact card">
    <div>
        <i class="far fa-user-circle gravatar"></i>
    </div>
    <div class="info">
        <h2>Name: ${contactData.name}</h2>
        <button class="detailsBtn" @click=${toggleDetails}>Details</button>
        <div class="details" id=${contactData.id}>
            <p>Phone number: ${contactData.phoneNumber}</p>
            <p>Email: ${contactData.email}</p>
        </div>
    </div>
</div>
`;

const contactsDiv = document.querySelector('#contacts');

const result = contacts.map(x => template(x, toggleDetails));

render(result, contactsDiv);

function toggleDetails(e) {
    //const divToToggle = e.target.nextElementSibling;
    const parent = e.target.parentElement;
    const divToToggle = parent.querySelector('.details');

    divToToggle.style.display = divToToggle.style.display == ''
        ? 'block'
        : '';
}