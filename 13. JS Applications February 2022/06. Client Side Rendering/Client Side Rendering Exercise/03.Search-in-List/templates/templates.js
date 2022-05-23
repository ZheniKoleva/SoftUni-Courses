import { html } from './../../node_modules/lit-html/lit-html.js';
import { ifDefined } from './../../node_modules/lit-html/directives/if-defined.js';

export const townsTemplate = (towns) => html`
<ul>
    ${towns.map(townTemplate)}
</ul>
`;

const townTemplate = (town) => html`
    <li class=${ifDefined(town.class)}>${town.name}</li>
`;

export const resultTemplate = (count) => html`
    <span>${count} matches found</span>
`;