import { hasSession, showView } from './common.js';
import { showHome } from './homePage.js';
import { validateInputData, validateResponse } from './validations.js';

const section = document.querySelector('#add-movie');
const addMovieForm = section.querySelector('form');
addMovieForm.addEventListener('submit', createMovie);

export function showAddMovie() {
    showView(section);
}

async function createMovie(e) {
    e.preventDefault();

    const formData = new FormData(addMovieForm);
    const inputData = Object.fromEntries(formData);

    try {
        validateInputData(inputData);
        addMovieForm.reset();

        const movie = {
            title: inputData.title,
            description: inputData.description,
            img: inputData.imageUrl
        };

        await makeRequest(movie);
        alert('Movie added to catalog successfully!');
        showHome();

    } catch (error) {
        alert(error.message);
    }
}

async function makeRequest(inputData) {
    const url = 'http://localhost:3030/data/movies';
    const userToken = hasSession();

    const options = {
        method: 'post',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': userToken.accessToken
        },
        body: JSON.stringify(inputData)
    }

    const response = await fetch(url, options)
    validateResponse(response);
}



