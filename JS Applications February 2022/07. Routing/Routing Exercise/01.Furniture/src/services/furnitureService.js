import api from './api.js';

const url = 'http://localhost:3030/data/catalog';

async function getAll() {
    const result = await api.get(url);

    return result;
}

async function getById(id) {
    const result = await api.get(`${url}/${id}`);

    return result;
}

async function createFurniture(data) {
    const result = await api.post(url, data);

    return result;
}

async function updateFurniture(data, id) {
    const result = await api.put(`${url}/${id}`, data);

    return result;
}

async function deleteFurniture(id) {
    const result = await api.del(`${url}/${id}`);

    return result;
}

async function getOwnFurniture(userId) {
    const result = await api.get(`${url}?where=_ownerId%3D%22${userId}%22`);

    return result;
}

export default {
    getAll, 
    getById,
    getOwnFurniture,
    createFurniture,
    updateFurniture,
    deleteFurniture
}
