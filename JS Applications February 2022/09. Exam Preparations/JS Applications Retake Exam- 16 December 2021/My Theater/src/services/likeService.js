import api from './api.js';

const url = 'http://localhost:3030/data/likes';
const endPoints = {    
    getByTheater: (theaterId) => `?where=theaterId%3D%22${theaterId}%22&distinct=_ownerId&count`,
    getByUser: (theaterId, userId) => `?where=theaterId%3D%22${theaterId}%22%20and%20_ownerId%3D%22${userId}%22&count`,    
}

async function getAll() {
    const result = await api.get(url);

    return result;
}

async function likeTheater(theaterId) {
    const result = await api.post(url, theaterId);

    return result;
}

async function getByTheater(theaterId) {
    const result = await api.get(url + endPoints.getByTheater(theaterId));

    return result;
}

async function getByUser(theaterId, userId) {
    const result = await api.get(url + endPoints.getByUser(theaterId, userId));

    return result;
}

export default {
    getAll,
    getByTheater,
    getByUser,
    likeTheater
}