import * as validations from './validations.js';

const registerForm = document.querySelector('#register-form');
registerForm.addEventListener('submit', register);
const loginForm = document.querySelector('#login-form');
loginForm.addEventListener('submit', login);

async function register(e) {
    e.preventDefault();

    const url = 'http://localhost:3030/users/register';
    const formElement = e.target;
    const formData = new FormData(formElement);
    const userData = Object.fromEntries(formData);

    try {
        validations.validateUserInputData(userData);
        validations.validatePasswords(userData);
        formElement.reset();

        await makeRequest(userData, url);

        alert('User registered successfully!');

        location.assign('homeLogged.html');

    } catch (error) {
        location.assign('login.html');
        alert(error);
    }
}

async function login(e) {
    e.preventDefault();

    const url = 'http://localhost:3030/users/login';
    const formElement = e.target;
    const formData = new FormData(formElement);
    const userData = Object.fromEntries(formData);

    try {
        validations.validateUserInputData(userData);
        formElement.reset();

        await makeRequest(userData, url);

        alert('You logged in successffully!');
        location.assign('homeLogged.html');

    } catch (error) {
        location.assign('login.html');
        alert(error);
    }
}

async function makeRequest(userData, url) {
    try {
        const user = {
            email: userData.email,
            password: userData.password
        };

        const options = {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        };

        const response = await fetch(url, options);
        validations.validateResponse(response);
        const data = await response.json();

        const token = {
            accessToken: data.accessToken,
            userId: data._id
        }

        sessionStorage.setItem('token', JSON.stringify(token));
    } catch (error) {
        throw new Error(error.message);
    }
}