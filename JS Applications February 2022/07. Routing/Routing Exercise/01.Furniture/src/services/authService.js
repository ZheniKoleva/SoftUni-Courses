import api from './api.js';

const baseUrl = 'http://localhost:3030/users';

function getToken() {
    return JSON.parse(sessionStorage.token).accessToken;
}

function getUserEmail() {
    return JSON.parse(sessionStorage.token).email;
}

function getUserId() {
    return JSON.parse(sessionStorage.token).userId;
}

function isLogged() {
    return sessionStorage.token !== undefined;
}

async function login(userData) {       
    const response = await api.post(`${baseUrl}/login`, userData);    
    setToken(response);
}

async function register(userData) {       
    const response = await api.post(`${baseUrl}/register`, userData);    
    setToken(response);
}

async function logout(){
    await api.get(`${baseUrl}/logout`); 
    sessionStorage.clear();  
}

function setToken(responseData) {
    const token = {
        accessToken: responseData.accessToken,
        userId: responseData._id,
        email: responseData.email
    };

    sessionStorage.setItem('token', JSON.stringify(token));
}

export default {
    getToken,
    getUserId,
    getUserEmail,
    isLogged,
    login,  
    register, 
    logout 
}
