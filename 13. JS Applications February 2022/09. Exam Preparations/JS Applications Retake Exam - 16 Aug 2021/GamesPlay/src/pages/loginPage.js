import { loginTemplate } from './../templates/loginTemplate.js';
import validations from './../services/validations.js';
import authService from './../services/authService.js';

async function getView(cntx) {  
    const binded = logUser.bind(null, cntx);
    const template = loginTemplate(binded);
    cntx.renderView(template);
}

async function logUser(cntx, e) {
    e.preventDefault();
    
    const form = e.target;
    const formData = new FormData(form);
    const inputData = Object.fromEntries(formData);

    try {
        validations.validateInputs(inputData);        

        await authService.login({
            email: inputData.email, 
            password: inputData.password
        });

        form.reset();
        cntx.page.redirect('/');

    } catch (error) {
        alert(error.message);
    }
}

export default {
    getView
}