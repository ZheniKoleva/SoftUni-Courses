import api from './api.js';

const url = 'http://localhost:3030/data/albums';
const endPoints = {
    getAll: '?sortBy=_createdOn%20desc&distinct=name',
    getById: (id) => `/${id}`,
    update: (id) => `/${id}`,
    delete: (id) => `/${id}`,
    search: (query) => `?where=name%20LIKE%20%22${query}%22`
}

async function getAll() {
    const result = await api.get(url + endPoints.getAll);

    return result;
}

async function getById(id) {
    const result = await api.get(url + endPoints.getById(id));

    return result;
}

async function createAlbum(data) {
    const result = await api.post(url, data);

    return result;
}

async function updateAlbum(data, id) {
    const result = await api.put(url + endPoints.update(id), data);

    return result;
}

async function deleteAlbum(id) {
    const result = await api.del(url + endPoints.delete(id));

    return result;
}

async function getByCriteria(query) {
    const result = await api.get(url + endPoints.search(query));

    return result;
}

export default {
    getAll, 
    getById,
    getByCriteria,
    createAlbum,
    updateAlbum,
    deleteAlbum
}
