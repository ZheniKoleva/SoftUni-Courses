import authService from './../services/authService.js';

export async function attachSession(cntx, next) {
    cntx.user = authService.isLogged();

    if(cntx.user) {
        cntx.token = authService.getToken();        
    }

    next();
}
