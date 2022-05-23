import { navbarTemplate } from '../templates/navbarTemplate.js';
import { render } from './../../node_modules/lit-html/lit-html.js';

const navbarContainer = document.querySelector('#site-header');
const mainContainer = document.querySelector('#site-content');

async function renderView(viewTemplate) {
    render(viewTemplate, mainContainer);
}

async function renderNavbar(viewTemplate) {
    render(viewTemplate, navbarContainer);
}

export function attachRender(cntx, next) { 
    renderNavbar(navbarTemplate(cntx));  
    cntx.renderView = renderView;
    next();
}