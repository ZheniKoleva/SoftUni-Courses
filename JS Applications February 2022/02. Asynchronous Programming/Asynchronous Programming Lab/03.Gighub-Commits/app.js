function loadCommits() {
    const ulElement = document.querySelector('#commits');
    ulElement.textContent = '';
    const usernameElement = document.querySelector('#username');
    const repoElement = document.querySelector('#repo');
    const username = usernameElement.value;
    const repo = repoElement.value;

    const url = `https://api.github.com/repos/${username}/${repo}/commits`;

    fetch(url)
        .then(response => validateResponse(response))
        .then(data => showCommits(data))
        .catch(error => showError(error));

    function validateResponse(response) {
        if (response.status == 404) {
            throw new Error(`Error: ${response.status} (Not Found)`);
        }

        return response.json();
    }

    function showCommits(data) {
        data.map(x => createLiElements(x))
            .forEach(x => ulElement.appendChild(x));
    }

    function showError(error) {
        const liElement = document.createElement('li');
        liElement.textContent = error.message;
        ulElement.appendChild(liElement);
    }

    function createLiElements(x) {
        const liElement = document.createElement('li');
        liElement.textContent = `${x.commit.author.name}: ${x.commit.message}`;

        return liElement;
    }
}