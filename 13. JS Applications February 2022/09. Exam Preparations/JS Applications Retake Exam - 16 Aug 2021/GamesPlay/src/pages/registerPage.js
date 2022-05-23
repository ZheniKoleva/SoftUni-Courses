import { registerTemplate } from "./../templates/registerTemplate.js";
import validations from './../services/validations.js';
import authService from './../services/authService.js';

async function getView(cntx) {
    const binded = registerUser.bind(null, cntx);
    const template = registerTemplate(binded);
    cntx.renderView(template);  
}

async function registerUser(cntx, e) {
    e.preventDefault();

    const form = e.target;
    const formData = new FormData(form);
    const data = Object.fromEntries(formData);

    try {
        validations.validateInputs(data);
        validations.validatePasswords(data.password, data['confirm-password']);

        const userData = {            
            email: data.email,
            password: data.password,           
        };

        await authService.register(userData);
        form.reset();       
        cntx.page.redirect('/');

    } catch (error) {        
        alert(error.message);
    }    
}

export default {
    getView
}