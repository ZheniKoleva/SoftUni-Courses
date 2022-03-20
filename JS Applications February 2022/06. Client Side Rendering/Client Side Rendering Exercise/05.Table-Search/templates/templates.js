import { html } from './../../node_modules/lit-html/lit-html.js';
import { ifDefined } from './../../node_modules/lit-html/directives/if-defined.js';

export const rowTemplate = (rowsData) => html`
    ${rowsData.map(studentTemplate)}
`;

const studentTemplate = (studentData) => html`
<tr class=${ifDefined(studentData.class)}>
    <td>${studentData.name}</td>
    <td>${studentData.email}</td>
    <td>${studentData.course}</td>
</tr>
`;