import {html, render} from '../node_modules/lit-html/lit-html.js';

const template = (towns) => html
`
<ul>
    ${towns.map(x => html`<li>${x}</li>`)};
</ul>
`;

const root = document.querySelector('#root');
const form = document.querySelector('form');
form.addEventListener('submit', visualizeTowns);

function visualizeTowns(e) {
    e.preventDefault();

    const formData = new FormData(form);
    const towns = formData.get('towns').split(', ');   
    form.reset();

    render(template(towns), root);
}