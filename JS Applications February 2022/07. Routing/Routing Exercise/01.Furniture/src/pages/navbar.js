import authService from '../services/authService.js';
import { navbarTemplate } from './../templates/navbarTemplate.js';

export async function navbarView(cntx, next) {  
    const isLogged = authService.isLogged();
    const template = navbarTemplate(cntx, isLogged);
    cntx.renderNavbar(template);
    next();
}