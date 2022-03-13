import { toggleNavBar } from "./nav.js";
import { showHome } from "./homePage.js";
import { showLogin } from "./loginPage.js";
import { showRegister } from "./registerPage.js";
import { showAddMovie } from "./addMoviePage.js";
import { showEditMovie } from "./editMoviePage.js";
import { logout } from "./logout.js";

const routes = {
    '/': showHome,
    '/login': showLogin,
    '/register': showRegister,
    '/addMovie': showAddMovie,
    '/editMovie': showEditMovie,
    '/logout': logout    
};

document.querySelector('nav').addEventListener('click', getView);
document.querySelector('#add-movie-button a').addEventListener('click', getView);

function getView(e) {
    if (e.target.tagName == 'A' && e.target.href) {
        e.preventDefault();
        
        const url = new URL(e.target.href);
        const viewToLoad = routes[url.pathname];

        if (typeof viewToLoad == 'function') {
            viewToLoad();
        }
    }
}

toggleNavBar();
showHome();