import { hasSession, showView } from "./common.js";
import { detailsPage } from "./detailsPage.js";
import { validateInputData, validateResponse } from "./validations.js";

const section = document.querySelector('#edit-movie');
const editForm = section.querySelector('form');
editForm.addEventListener('submit', updateMovie);

let movieId = '';

export function showEditMovie(){
    showView(section);
}

export async function editMovie(e) {
    e.preventDefault();
    showEditMovie();

    movieId = e.target.dataset.movieId;
    const movieToEdit = e.target.parentElement.parentElement;
    let title = movieToEdit.querySelector('h1').textContent;
    title = title.replace('Movie title: ', '');
    const imageUrl = movieToEdit.querySelector('img').src;
    const description = movieToEdit.querySelector('p').textContent;

    const movieData = { title, description, imageUrl };
    Object.keys(movieData)
        .forEach(key => editForm[key].value = movieData[key]);
}

async function updateMovie(e) {
    e.preventDefault();

    const formData = new FormData(editForm);
    const newMovieData = Object.fromEntries(formData);

    try {
        validateInputData(newMovieData);
        editForm.reset();

        const movieData = {
            title: newMovieData.title,
            description: newMovieData.description,
            img: newMovieData.imageUrl
        };

        await makeRequest(movieData, movieId);
        alert('Movie edited successfully!');
        detailsPage(movieId);

    } catch (error) {
        alert(error.message);
    }
}

async function makeRequest(movieData, movieId) {
    const url = `http://localhost:3030/data/movies/${movieId}`;
    const userToken = hasSession();

    const options = {
        method: 'put',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': userToken.accessToken
        },
        body: JSON.stringify(movieData)
    };

    const response = await fetch(url, options);
    validateResponse(response);
}