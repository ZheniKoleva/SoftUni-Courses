import { html } from './../../node_modules/lit-html/lit-html.js';
import { carTemplate } from './carTemplate.js';

export const carsTemplate = (cars) => html`
<section id="my-listings">
    <h1>My car listings</h1>
    <div class="listings">
        ${cars.length > 0 
            ? html`${cars.map(carTemplate)}`
            : html`<p class="no-cars"> You haven't listed any cars yet.</p>`        
        }
    </div>
</section>
`;
