import { html } from './../../node_modules/lit-html/lit-html.js';

export const allOptionsTemplate = (options) => html`
    ${options.map(optionTemplate)}
`;

const optionTemplate = (optionData) => html`
    <option .value=${optionData._id}>${optionData.text}</option>
`;