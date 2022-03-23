import { render } from './../../node_modules/lit-html/lit-html.js';

let navbarContainer = '';
let mainContainer = '';

export function assignContainers(navbarElement, mainElement) {
    navbarContainer = navbarElement;
    mainContainer = mainElement;
}

async function renderView(viewTemplate) {
    render(viewTemplate, mainContainer);
}

async function renderNavbar(viewTemplate) {
    render(viewTemplate, navbarContainer);
}

export function attachToContext(cntx, next) {
    cntx.renderNavbar = renderNavbar;
    cntx.renderView = renderView;
    next();
}