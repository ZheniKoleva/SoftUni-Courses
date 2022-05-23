import authService from "../services/authService.js";
import validations from './../services/validations.js';
import { loginTemplate } from "../templates/loginTemplate.js";

export async function loginView(cntx) { 
    const binded = loginUser.bind(null, cntx);
    const template = loginTemplate(binded);
    cntx.renderView(template);
}

async function loginUser(cntx, e) {
    e.preventDefault();

    const form = e.target;
    const formData = new FormData(form);
    const data = Object.fromEntries(formData);

    try {
        validations.validateInputs(data);
        await authService.login(data);
        form.reset();
        alert('User logged in successfully!');
        cntx.page.redirect('/dashboard');

    } catch (error) {
        alert(error.message);
    }    
}
