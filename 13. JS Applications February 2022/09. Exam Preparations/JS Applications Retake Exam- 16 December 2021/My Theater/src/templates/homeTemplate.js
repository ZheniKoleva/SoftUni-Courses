import { html } from './../../node_modules/lit-html/lit-html.js';
import { theaterTemplate } from './theaterTemplate.js';

export const homeTemplate = (theaters) => html`
<section class="welcomePage">
    <div id="welcomeMessage">
        <h1>My Theater</h1>
        <p>Since 1962 World Theatre Day has been celebrated by ITI Centres, ITI Cooperating Members, theatre
            professionals, theatre organizations, theatre universities and theatre lovers all over the world on
            the 27th of March. This day is a celebration for those who can see the value and importance of the
            art
            form “theatre”, and acts as a wake-up-call for governments, politicians and institutions which have
            not
            yet recognised its value to the people and to the individual and have not yet realised its potential
            for
            economic growth.</p>
    </div>
    <div id="events">
        <h1>Future Events</h1>
        <div class="theaters-container">
            ${theaters.length > 0
                ? html`${theaters.map(theaterTemplate)}`
                : html`<h4 class="no-event">No Events Yet...</h4>`            
            }  
        </div>
    </div>
</section>
`;