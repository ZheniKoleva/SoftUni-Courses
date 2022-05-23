import page from './../node_modules/page/page.mjs';
import authService from './services/authService.js';
import { assignContainers, attachToContext } from './services/renderer.js';
import { navbarView } from './pages/navbar.js'
import { dashboardView } from './pages/dashboard.js';
import { loginView } from './pages/login.js';
import { registerView } from './pages/register.js';
import { detailsView } from './pages/details.js';
import { createView } from './pages/create.js';
import { editView } from './pages/edit.js';
import { myFurnitureView } from './pages/myFurniture.js';

const navbar = document.querySelector('#nav-container');
const main = document.querySelector('#main-container');

assignContainers(navbar, main);

page('/', '/dashboard');
page('/index.html', '/dashboard');

page('/dashboard', attachToContext, navbarView, dashboardView);
page('/login', attachToContext, navbarView, loginView);
page('/register', attachToContext, navbarView, registerView);
page('/logout', async (cntx) => {
    await authService.logout();
    alert('Logout successfull!')
    cntx.page.redirect('/dashboard');
});
page('/details/:id', attachToContext, navbarView, detailsView);
page('/create', attachToContext, navbarView, createView);
page('/edit/:id', attachToContext, navbarView, editView);
page('/my-furniture', attachToContext, navbarView, myFurnitureView);

page.start();
