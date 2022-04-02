import api from './api.js';

const url = 'http://localhost:3030/data/theaters';
const endPoints = {
    getAll: '?sortBy=_createdOn%20desc&distinct=title',
    getById: (id) => `/${id}`,
    update: (id) => `/${id}`,
    delete: (id) => `/${id}`,
    getByOwner: (ownerId) => `?where=_ownerId%3D%22${ownerId}%22&sortBy=_createdOn%20desc`
}

async function getAll() {
    const result = await api.get(url + endPoints.getAll);

    return result;
}

async function getById(id) {
    const result = await api.get(url + endPoints.getById(id));

    return result;
}

async function createTheater(data) {
    const result = await api.post(url, data);

    return result;
}

async function updateTheater(data, id) {
    const result = await api.put(url + endPoints.update(id), data);

    return result;
}

async function deleteTheater(id) {
    const result = await api.del(url + endPoints.delete(id));

    return result;
}

async function getByOwner(query) {
    const result = await api.get(url + endPoints.getByOwner(query));

    return result;
}

export default {
    getAll, 
    getById,
    getByOwner,
    createTheater,
    updateTheater,
    deleteTheater
}
