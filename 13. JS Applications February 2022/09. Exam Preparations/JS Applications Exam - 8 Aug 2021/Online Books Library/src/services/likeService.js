import api from './api.js';

const url = 'http://localhost:3030/data/likes';
const endPoints = {    
    getByBook: (bookId) => `?where=bookId%3D%22${bookId}%22&distinct=_ownerId&count`,
    getByUser: (bookId, userId) => `?where=bookId%3D%22${bookId}%22%20and%20_ownerId%3D%22${userId}%22&count`,    
}

async function getAll() {
    const result = await api.get(url);

    return result;
}

async function likeBook(bookId) {
    const result = await api.post(url, bookId);

    return result;
}

async function getByBook(bookId) {
    const result = await api.get(url + endPoints.getByBook(bookId));

    return result;
}

async function getByUser(bookId, userId) {
    const result = await api.get(url + endPoints.getByUser(bookId, userId));

    return result;
}

export default {
    getAll,
    getByBook,
    getByUser,
    likeBook
}