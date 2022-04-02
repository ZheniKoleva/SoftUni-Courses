import api from './api.js';

const url = 'http://localhost:3030/data/games';
const endPoints = {
    getAll: '?sortBy=_createdOn%20desc',
    getLatest: '?sortBy=_createdOn%20desc&distinct=category',
    getById: (id) => `/${id}`,
    update: (id) => `/${id}`,
    delete: (id) => `/${id}`,    
}

async function getAll() {
    const result = await api.get(url + endPoints.getAll);

    return result;
}

async function getLatest() {
    const result = await api.get(url + endPoints.getLatest);

    return result;
}

async function getById(id) {
    const result = await api.get(url + endPoints.getById(id));

    return result;
}

async function createGame(data) {
    const result = await api.post(url, data);

    return result;
}

async function updateGame(data, id) {
    const result = await api.put(url + endPoints.update(id), data);

    return result;
}

async function deleteGame(id) {
    const result = await api.del(url + endPoints.delete(id));

    return result;
}



export default {
    getAll, 
    getById,
    getLatest,
    createGame,
    updateGame,
    deleteGame
}
