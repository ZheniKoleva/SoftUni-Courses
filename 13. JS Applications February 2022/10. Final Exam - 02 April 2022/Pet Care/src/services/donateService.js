import api from './api.js';

const url = 'http://localhost:3030/data/donation';
const endPoints = {    
    getByPetId: (petId) => `?where=petId%3D%22${petId}%22&distinct=_ownerId&count`,
    getByUser: (petId, userId) => `?where=petId%3D%22${petId}%22%20and%20_ownerId%3D%22${userId}%22&count`,    
}

async function donate(petId) {
    const result = await api.post(url, petId);

    return result;
}

async function getByPetId(petId) {
    const result = await api.get(url + endPoints.getByPetId(petId));

    return result;
}

async function getByUser(petId, userId) {
    const result = await api.get(url + endPoints.getByUser(petId, userId));

    return result;
}

export default {  
    donate, 
    getByPetId,
    getByUser  
}