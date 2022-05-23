import { html } from './../../node_modules/lit-html/lit-html.js';
import { carTemplate } from './carTemplate.js';

export const allCarsTemplate = (cars) => html`
<section id="car-listings">
    <h1>Car Listings</h1>
    <div class="listings">
        ${cars.length > 0
            ? html`${cars.map(carTemplate)}`
            : html`<p class="no-cars">No cars in database.</p>`
        }       
    </div>
</section>
`;

