import { registerTemplate } from "./../templates/registerTemplate.js";
import notifications from './../services/notifications.js';
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
        validations.validatePasswords(data.password, data.repeatPass);

        const userData = {
            username: data.username,
            email: data.email,
            password: data.password,
            gender: data.gender
        };

        await authService.register(userData);
        form.reset();       
        cntx.page.redirect('/all');

    } catch (error) {        
        notifications.showNotification(error.message);
    }    
}

export default {
    getView
}