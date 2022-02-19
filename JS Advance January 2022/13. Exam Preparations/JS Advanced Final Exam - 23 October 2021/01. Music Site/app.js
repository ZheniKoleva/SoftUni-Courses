window.addEventListener('load', solve);

function solve() {
    const addButton = document.querySelector('#add-btn');
    addButton.addEventListener('click', appendSong);
    const formInputData = addButton.parentElement;

    const songsCollectionArea = document.querySelector('#all-hits div.all-hits-container');
    const totalLikesArea = document.querySelector('#total-likes div.likes > p');
    const savedSongsArea = document.querySelector('#saved-hits div.saved-container');

    function appendSong(e) {
        e.preventDefault();

        const genreElement = formInputData.querySelector('#genre');
        const nameElement = formInputData.querySelector('#name');
        const authorElement = formInputData.querySelector('#author');
        const dateElement = formInputData.querySelector('#date');

        if (genreElement.value
            && nameElement.value
            && authorElement.value
            && dateElement.value) {

            const divElement = createElement('div');
            divElement.classList.add('hits-info');

            const attributeValue = './static/img/img.png';
            const imgElement = createElement('img', undefined, 'src', attributeValue);
            divElement.appendChild(imgElement);

            const h2GenreText = `Genre: ${genreElement.value}`;
            const h2GenreElement = createElement('h2', h2GenreText);
            divElement.appendChild(h2GenreElement);

            const h2NameText = `Name: ${nameElement.value}`;
            const h2NameElement = createElement('h2', h2NameText);
            divElement.appendChild(h2NameElement);

            const h2AuthorText = `Author: ${authorElement.value}`;
            const h2AuthorElement = createElement('h2', h2AuthorText);
            divElement.appendChild(h2AuthorElement);

            const h3DateText = `Date: ${dateElement.value}`;
            const h3DateElement = createElement('h3', h3DateText);
            divElement.appendChild(h3DateElement);

            const saveButton = createElement('button', 'Save song');
            saveButton.classList.add('save-btn');
            saveButton.addEventListener('click', saveSong);
            divElement.appendChild(saveButton);

            const likeButton = createElement('button', 'Like song');
            likeButton.classList.add('like-btn');
            likeButton.addEventListener('click', likeSong);
            divElement.appendChild(likeButton);

            const deleteButton = createElement('button', 'Delete');
            deleteButton.classList.add('delete-btn');
            deleteButton.addEventListener('click', deleteSong);
            divElement.appendChild(deleteButton);

            songsCollectionArea.appendChild(divElement);

            genreElement.value = '';
            nameElement.value = '';
            authorElement.value = '';
            dateElement.value = '';
        }
    }

    function saveSong(e) {
        const songToMove = e.target.parentElement;
        songToMove.querySelector('.save-btn').remove();
        songToMove.querySelector('.like-btn').remove();

        savedSongsArea.appendChild(songToMove);
    }

    function likeSong(e) {
        e.target.setAttribute('disabled', true);

        let [text, currentLikes] = totalLikesArea.textContent.split(': ');
        currentLikes = Number(currentLikes);
        currentLikes++;

        totalLikesArea.textContent = `${text}: ${currentLikes}`;
    }

    function deleteSong(e) {
        const songToDelete = e.target.parentElement;
        songToDelete.remove();
    }

    function createElement(type, textContent, attributeName, attributeValue) {
        const element = document.createElement(type);

        if (textContent) {
            element.textContent = textContent;
        }

        if (attributeName) {
            element.setAttribute(attributeName, attributeValue);
        }

        return element;
    }
}