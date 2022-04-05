import api from './api.js';

const baseUrl = 'http://localhost:3030/users';
const endPoints = {
    login: '/login',
    register: '/register',
    logout: '/logout'
}

export function getToken() {
    return JSON.parse(sessionStorage.token);
}

function getAccessToken() {
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
    const response = await api.post(baseUrl + endPoints.login, userData);    
    setToken(response);
}

async function register(userData) {       
    const response = await api.post(baseUrl + endPoints.register, userData);    
    setToken(response);
}

async function logout(){    
    await api.get(baseUrl + endPoints.logout); 
    sessionStorage.clear();  
}

function setToken(responseData) {
    const token = {
        accessToken: responseData.accessToken,
        userId: responseData._id,
        email: responseData.email,
        password: responseData.password
    };

    sessionStorage.setItem('token', JSON.stringify(token));
}

export default { 
    getToken,   
    getAccessToken,
    getUserId,
    getUserEmail,
    isLogged,
    login,  
    register, 
    logout,
}
