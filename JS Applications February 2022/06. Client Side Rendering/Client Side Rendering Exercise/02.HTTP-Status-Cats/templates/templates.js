import { html } from './../../node_modules/lit-html/lit-html.js';

export const allCatsTemplate = (cats, eventFunction) => html`
<ul>
    ${cats.map(x => catTemplate(x, eventFunction))};
</ul>
`;

export const catTemplate = (catData, eventFunction) => html`
<li>
    <img src="./images/${catData.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
    <div class="info">
        <button class="showBtn" @click=${eventFunction}>Show status code</button>
        <div class="status" style="display: none" id=${catData.id}>
            <h4>Status Code: ${catData.statusCode}</h4>
            <p>${catData.statusMessage}</p>
        </div>
    </div>
</li>
`;