import { html, nothing } from './../../node_modules/lit-html/lit-html.js';

export const detailsTemplate = (formData) => html`
<section id="detailsPage">
    <div class="details">
        <div class="animalPic">
            <img src=${formData.pet.image}>
        </div>
        <div>
            <div class="animalInfo">
                <h1>Name: ${formData.pet.name}</h1>
                <h3>Breed: ${formData.pet.breed}</h3>
                <h4>Age: ${formData.pet.age}</h4>
                <h4>Weight: ${formData.pet.weight}</h4>
                <h4 class="donation">Donation: ${formData.donations}$</h4>
            </div>

            ${formData.isLogged
                ? html`<div class="actionBtn"> ${generateButtons(formData)}</div>`
                : nothing 
            } 
        </div>
    </div>
</section>
`;

function generateButtons(formData) { 
    const buttons = [];

    if (formData.isOwner) {
        const updateBtns = html`
            <a href="/edit/${formData.pet._id}" class="edit">Edit</a>
            <a href="javascript:void(0)" class="remove" @click=${formData.deletePet}>Delete</a>
        `;

        buttons.push(updateBtns);
    }

    if (!formData.isOwner && !formData.isUserDonate) {
        const donateBtn = html`<a href="#" class="donate" @click=${formData.donate}>Donate</a>`; //javascript:void(0) breaks the last two E2E tests

        buttons.push(donateBtn);
    }

    return buttons;
}