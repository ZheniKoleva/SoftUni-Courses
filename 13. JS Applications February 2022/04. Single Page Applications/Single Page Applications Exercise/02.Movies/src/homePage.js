import { hasSession, showView } from './common.js';
import { validateResponse } from './validations.js';
import { detailsPage } from './detailsPage.js';

const homeSection = document.querySelector('#home-page');
const movieSection = document.querySelector('#movie');
const movieCatalog = movieSection.querySelector('div.card-deck.d-flex.justify-content-center');
movieCatalog.addEventListener('click', getMovieDetails);
const addMovieBtn = document.querySelector('#add-movie-button');

export function showHome() {
    loadMovies();
    showView(homeSection);
    const session = hasSession();

    if (session) {
        addMovieBtn.style.display = 'block';
    }

    movieSection.style.display = 'block';
}

async function loadMovies() {
    try {       
        const movies = await makeRequest();
        const movieElements = movies
            .map(x => createElement(x));

        movieCatalog.replaceChildren(...movieElements);
    } catch (error) {
        alert(error.message);
    }
}

async function makeRequest() {
    const url = 'http://localhost:3030/data/movies';
    const response = await fetch(url);
    validateResponse(response);
    const data = await response.json();

    return data;
}

function createElement(movieData) {
    const element = document.createElement('div');
    element.className = 'card mb-4';
    element.innerHTML = `
<img class="card-img-top" src="${movieData.img}"
    alt="Card image cap" width="400">
<div class="card-body">
   <h4 class="card-title">${movieData.title}</h4>
</div>
<div class="card-footer">
   <a href="/details/${movieData._id}">
       <button data-id="${movieData._id}" type="button" class="btn btn-info">Details</button>
   </a>
</div>`;

    return element;
}

function getMovieDetails(e) {
    if (e.target.tagName == 'BUTTON') {
        e.preventDefault();
        const id = e.target.dataset.id;
        detailsPage(id);
    }
}