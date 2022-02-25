function loadRepos() {
	const ulElement = document.querySelector('#repos');
	ulElement.textContent = '';
	const inputElement = document.querySelector('#username');
	const searchedUsername = inputElement.value;

	const url = `https://api.github.com/users/${searchedUsername}/repos`;

	fetch(url)
		.then(response => {
			if (response.status == 404) {
				throw new Error(`Error: ${response.status} (Username ${searchedUsername} not found)`);
			}

			return response.json();
		})
		.then(data => createLinks(data))
		.catch(error => ulElement.textContent = `${error.message}`);

	function createLinks(data) {
		data.map(x => createLiElements(x))
			.forEach(x => ulElement.appendChild(x));
	}

	function createLiElements(x) {
		const liElement = document.createElement('li');
		const aElement = document.createElement('a');
		aElement.setAttribute('href', `${x.html_url}`);
		aElement.textContent = `${x.full_name}`;

		liElement.appendChild(aElement);

		return liElement;
	}
}