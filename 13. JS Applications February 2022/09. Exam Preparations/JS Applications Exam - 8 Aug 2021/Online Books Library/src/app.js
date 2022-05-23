import page from './../node_modules/page/page.mjs';

import addPage from './pages/addPage.js';
import editPage from './pages/editPage.js';
import loginPage from './pages/loginPage.js';
import detailsPage from './pages/detailsPage.js';
import myBooksPage from './pages/myBooksPage.js';
import registerPage from './pages/registerPage.js';
import dashboardPage from './pages/dashboardPage.js';

import { attachSession} from './middlewares/session.js';
import { attachRender } from './middlewares/renderer.js';
import authService from './services/authService.js';

page(attachSession);
page(attachRender);

page('/index.html', dashboardPage.getView);
page('/', dashboardPage.getView);

page('/login', loginPage.getView);
page('/register', registerPage.getView);
page('/add', addPage.getView);
page('/edit/:id', editPage.getView);
page('/details/:id', detailsPage.getView);
page('/myBooks', myBooksPage.getView);
page('/logout', async (cntx) => {
    await authService.logout();
    cntx.page.redirect('/')});

page.start();