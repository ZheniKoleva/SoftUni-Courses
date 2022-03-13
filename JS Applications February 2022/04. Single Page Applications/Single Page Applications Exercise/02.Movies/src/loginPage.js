import {showView } from './common.js';
import { showHome } from './homePage.js';
import { toggleNavBar } from './nav.js';
import { validateInputData, validateResponse } from './validations.js';

const section = document.querySelector('#form-login');
const loginForm = section.querySelector('form');
loginForm.addEventListener('submit', loginUser);

export function showLogin() {
    showView(section);
}

async function loginUser(e) {
    e.preventDefault();

    const formData = new FormData(loginForm);
    const inputData = Object.fromEntries(formData);

    try {
        validateInputData(inputData);
        loginForm.reset();

        await makeRequest(inputData);
         
        alert('You logged in successfully!');      
        toggleNavBar();
        showHome();

    } catch (error) {
        alert(error.message);
    }
}

async function makeRequest(inputData) {
    const url = 'http://localhost:3030/users/login';

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

