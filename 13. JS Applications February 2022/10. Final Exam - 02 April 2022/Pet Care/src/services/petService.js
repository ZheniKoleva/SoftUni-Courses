import api from './api.js';

const url = 'http://localhost:3030/data/pets';
const endPoints = {
    getAll: '?sortBy=_createdOn%20desc&distinct=name',
    getById: (id) => `/${id}`,
    update: (id) => `/${id}`,
    delete: (id) => `/${id}`,    
}

async function getAll() {
    const result = await api.get(url + endPoints.getAll);

    return result;
}

async function getById(id) {
    const result = await api.get(url + endPoints.getById(id));

    return result;
}

async function createPet(data) {
    const result = await api.post(url, data);

    return result;
}

async function updatePet(data, id) {
    const result = await api.put(url + endPoints.update(id), data);

    return result;
}

async function deletePet(id) {
    const result = await api.del(url + endPoints.delete(id));

    return result;
}

export default {
    getAll, 
    getById,    
    createPet,
    updatePet,
    deletePet
}
