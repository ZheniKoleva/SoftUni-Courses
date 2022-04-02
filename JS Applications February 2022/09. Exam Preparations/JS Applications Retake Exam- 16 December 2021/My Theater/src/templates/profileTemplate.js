import { html } from './../../node_modules/lit-html/lit-html.js';

export const profileTemplate = (user, events) => html`
<section id="profilePage">
    <div class="userInfo">
        <div class="avatar">
            <img src="./images/profilePic.png">
        </div>
        <h2>${user}</h2>
    </div>
    <div class="board">
        ${events.length > 0 
            ? html`${events.map(eventTemplate)}`
            : noEventTemplate()
        }       
    </div>
</section>
`;

const eventTemplate = (event) => html`
<div class="eventBoard">
    <div class="event-info">
        <img src=${event.imageUrl}>
        <h2>${event.title}</h2>
        <h6>${event.date}</h6>
        <a href="/details/${event._id}" class="details-button">Details</a>
    </div>
</div>
`;

const noEventTemplate = () => html`
<div class="no-events">
    <p>This user has no events yet!</p>
</div>
`;
