import { hasSession, showView } from './common.js';
import { validateResponse } from './validations.js'
import { showHome } from './homePage.js';
import { editMovie } from './editMoviePage.js';

const section = document.querySelector('#movie-example');

export function detailsPage(id) {   
    showMovieData(id);
    showView(section);
}

async function showMovieData(id) {
    const userToken = hasSession();

    const [movie, likes, ownLike] = await Promise.all([
        getMovie(id),
        getLikes(id),
        getOwnLikes(id, userToken)
    ]);

    const buttonsToShow = createButtons(movie, ownLike, likes, userToken);
    const movieDetails = generateHTMLElement(movie, buttonsToShow);
    attachButtonsEvents(movieDetails);

    section.replaceChildren(movieDetails);
}

async function getMovie(id) {
    const url = `http://localhost:3030/data/movies/${id}`;
    const movie = await makeRequest(url);
    return movie;
}

async function getLikes(id) {
    const url = `http://localhost:3030/data/likes?where=movieId%3D%22${id}%22&distinct=_ownerId&count`;
    const likes = await makeRequest(url);
    return likes;
}

async function getOwnLikes(id, userToken) {
    if (!userToken) {
        return false;
    }

    const url = `http://localhost:3030/data/likes?where=movieId%3D%22${id}%22%20and%20_ownerId%3D%22${userToken.userId}%22`;
    const likes = await makeRequest(url);
    return likes.length > 0;
}


async function makeRequest(url) {
    try {
        const response = await fetch(url);
        validateResponse(response);
        const data = await response.json();

        return data;
    } catch (error) {
        alert(error.message);
    }
}

function generateHTMLElement(movie, buttonsToShow) {
    const element = document.createElement('div');
    element.classList.add('container');
    element.innerHTML = `
    <div class="row bg-light text-dark">
        <h1>Movie title: ${movie.title}</h1>
                
        <div class="col-md-8">
            <img class="img-thumbnail" src="${movie.img}" alt="Movie">
        </div>
        <div class="col-md-4 text-center">
            <h3 class="my-3 ">Movie Description</h3>
            <p>${movie.description}</p>
            ${buttonsToShow}            
        </div>
    </div>`;

    return element;
}

function createButtons(movie, ownLike, likes, userToken) {
    const isOwner = userToken && userToken.userId == movie._ownerId;

    let controls = [];

    if (isOwner) {
        controls.push(`<a data-id="deleteBtn" data-movie-Id="${movie._id}" class="btn btn-danger" href="#">Delete</a>`);
        controls.push(`<a data-id="editBtn" data-movie-Id="${movie._id}" class="btn btn-warning" href="/editMovie">Edit</a>`);
        controls.push(`<span class="enrolled-span">Liked ${likes}</span>`);
    } else if (userToken && ownLike == false) {
        controls.push(`<a data-id="likeBtn" data-movie-Id="${movie._id}" class="btn btn-primary" href="#">Like</a>`);
    } else {
        controls.push(`<span class="enrolled-span">Liked ${likes}</span>`);
    } 
    
    return controls.join('');
}

function attachButtonsEvents(movieElement) {
    const likeBtn = movieElement.querySelector('[data-id="likeBtn"]');
    if (likeBtn) {
        likeBtn.addEventListener('click', likeMovie);
    }

    const deleteBtn = movieElement.querySelector('[data-id="deleteBtn"]');
    if (deleteBtn) {
        deleteBtn.addEventListener('click', deleteMovie);
    }

    const editBtn = movieElement.querySelector('[data-id="editBtn"]');
    if (editBtn) {
        editBtn.addEventListener('click', editMovie);
    }
}

async function likeMovie(e) {
    e.preventDefault();
    const movieId = e.target.dataset.movieId;

    const url = 'http://localhost:3030/data/likes';
    const userToken = hasSession();

    try {
        const options = {
            method: 'post',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': userToken.accessToken
            },
            body: JSON.stringify({ movieId })
        };

        const response = await fetch(url, options);
        validateResponse(response);

        await getNewLikeCounts(movieId);

    } catch (error) {
        alert(error.message);
    }
}

async function getNewLikeCounts(movieId) {
    const likeBtn = section.querySelector('[data-id="likeBtn"]');
    likeBtn.removeEventListener('click', likeMovie);
    
    const likesCount = await getLikes(movieId);

    const likesSpan = document.createElement('span');
    likesSpan.classList.add('enrolled-span');
    likesSpan.textContent = `Liked ${likesCount}`;

    likeBtn.replaceWith(likesSpan);
}

async function deleteMovie(e) {
    e.preventDefault();
    const movieId = e.target.dataset.movieId;

    e.target.removeEventListener('click', deleteMovie);

    const url = `http://localhost:3030/data/movies/${movieId}`;
    const userToken = hasSession();

    const options = {
        method: 'delete',
        headers: {
            'X-Authorization': userToken.accessToken
        }
    };

    try {
        const response = await fetch(url, options);
        validateResponse(response);
        alert('Movie deleted successfully!');
        showHome();
    } catch (error) {
        alert(error.message);
    }
}

