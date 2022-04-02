import api from './api.js';

const url = 'http://localhost:3030/data/cars';
const endPoints = {
    getAll: '?sortBy=_createdOn%20desc',
    getById: (id) => `/${id}`,
    update: (id) => `/${id}`,
    delete: (id) => `/${id}`,
    getByOwner: (ownerId) => `?where=_ownerId%3D%22${ownerId}%22&sortBy=_createdOn%20desc`,
    getByYear: (year) => `?where=year%3D${year}`,
}

async function getAll() {
    const result = await api.get(url + endPoints.getAll);

    return result;
}

async function getById(id) {
    const result = await api.get(url + endPoints.getById(id));

    return result;
}

async function createCar(data) {
    const result = await api.post(url, data);

    return result;
}

async function updateCar(data, id) {
    const result = await api.put(url + endPoints.update(id), data);

    return result;
}

async function deleteCar(id) {
    const result = await api.del(url + endPoints.delete(id));

    return result;
}

async function getByOwner(ownerId) {
    const result = await api.get(url + endPoints.getByOwner(ownerId));

    return result;
}

async function getByYear(year) {
    const result = await api.get(url + endPoints.getByYear(year));

    return result;
}

export default {
    getAll, 
    getById,
    getByOwner,
    getByYear,
    createCar,
    updateCar,
    deleteCar,
}
