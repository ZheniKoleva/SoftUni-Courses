import api from './api.js';

const url = 'http://localhost:3030/data/comments';
const endPoints = {    
    getByGame: (gameId) => `?where=gameId%3D%22${gameId}%22`,     
}

async function postComment(gameId) {
    const result = await api.post(url, gameId);

    return result;
}

async function getByGame(gameId) {
    const result = await api.get(url + endPoints.getByGame(gameId));

    return result;
}

export default {
    getByGame,
    postComment,    
}