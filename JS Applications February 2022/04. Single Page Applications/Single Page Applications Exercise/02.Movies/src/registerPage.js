import {showView } from './common.js';
import { showHome } from './homePage.js';
import { toggleNavBar } from './nav.js';
import { validateInputData, validatePasswords, validateResponse } from './validations.js';

const section = document.querySelector('#form-sign-up');
const registrationForm = section.querySelector('form');
registrationForm.addEventListener('submit', registerUser);

export function showRegister() {
    showView(section);
}

async function registerUser(e) {
    e.preventDefault();

    const formData = new FormData(registrationForm);
    const inputData = Object.fromEntries(formData);

    try {
        validateInputData(inputData);
        validatePasswords(inputData.password, inputData.repeatPassword);
        delete inputData.repeatPassword;
        registrationForm.reset();

        await makeRequest(inputData); 
        alert('You registered successfully!');      
        toggleNavBar();
        showHome();

    } catch (error) {
        alert(error.message);
    }

}

async function makeRequest(inputData) {
    const url = 'http://localhost:3030/users/register';
    
    const options = {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(inputData)
    }

    const response = await fetch(url, options)
    validateResponse(response);
    const data = await response.json();

    const token = {
        accessToken: data.accessToken,
        userId: data._id,
        email: data.email
    }

    sessionStorage.setItem('token', JSON.stringify(token));
}