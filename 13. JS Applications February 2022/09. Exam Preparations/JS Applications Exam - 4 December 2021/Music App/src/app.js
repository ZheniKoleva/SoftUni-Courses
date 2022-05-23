import page from './../node_modules/page/page.mjs';

import editPage from './pages/editPage.js';
import homePage from './pages/homePage.js';
import loginPage from './pages/loginPage.js';
import createPage from './pages/createPage.js';
import searchPage from './pages/searchPage.js';
import catalogPage from './pages/catalogPage.js';
import detailsPage from './pages/detailsPage.js';
import registerPage from './pages/registerPage.js';

import { attachSession} from './middlewares/session.js';
import { attachRender } from './middlewares/renderer.js';
import authService from './services/authService.js';

page(attachSession);
page(attachRender);

page('/index.html', homePage.getView);
page('/', homePage.getView);

page('/login', loginPage.getView);
page('/register', registerPage.getView);
page('/catalog', catalogPage.getView);
page('/create', createPage.getView);
page('/edit/:id', editPage.getView);
page('/details/:id', detailsPage.getView);
page('/search', searchPage.getView);
page('/logout', async (cntx) => {
    await authService.logout();
    cntx.page.redirect('/')});

page.start();