import authService from "../services/authService.js";
import validations from './../services/validations.js';
import { registerTemplate } from "../templates/registerTemplate.js";


export async function registerView(cntx) { 
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
        validations.validatePasswords(data.password, data.rePass);

        const userData = {
            email: data.email,
            password: data.password
        };

        await authService.register(userData);
        form.reset();
        alert('User registered successfully!');
        cntx.page.redirect('/dashboard');

    } catch (error) {        
        alert(error.message);
    }    
}
