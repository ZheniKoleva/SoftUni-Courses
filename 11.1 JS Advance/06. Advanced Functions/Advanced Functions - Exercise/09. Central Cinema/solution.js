function solve() {
    const addMovieSection = document.querySelector('#add-new');
    const onScreenButton = addMovieSection.querySelector('#container button');
    onScreenButton.addEventListener('click', addMovie);
    const inputDataElement = addMovieSection.querySelector('#container');

    const moviesSectionUl = document.querySelector('#movies ul');
    const archiveSectionUl = document.querySelector('#archive ul');
    const archiveClearButton = document.querySelector('#archive button');
    archiveClearButton.addEventListener('click', clearAllArchivedMovies);

    function addMovie(e) {
        e.preventDefault();

        const movieTextElement = inputDataElement.querySelector('input[placeholder="Name"]');
        const hallNameTextElement = inputDataElement.querySelector('input[placeholder="Hall"]');
        const ticketPriceTextElement = inputDataElement.querySelector('input[placeholder="Ticket Price"]');

        if (movieTextElement.value && hallNameTextElement.value
            && Number(ticketPriceTextElement.value)) {

            const movieName = movieTextElement.value;
            const hallName = hallNameTextElement.value;
            const price = Number(ticketPriceTextElement.value);

            const liElement = document.createElement('li');

            const spanElement = document.createElement('span');
            spanElement.textContent = movieName;

            const strongElement = document.createElement('strong');
            strongElement.textContent = `Hall: ${hallName}`;

            const divElement = document.createElement('div');
            const strongPriceElement = document.createElement('strong');
            strongPriceElement.textContent = price.toFixed(2);            
            const inputElement = document.createElement('input');
            inputElement.placeholder = 'Tickets Sold';
            const buttonElement = document.createElement('button');
            buttonElement.textContent = 'Archive';
            buttonElement.addEventListener('click', archiveMovie);

            divElement.appendChild(strongPriceElement);
            divElement.appendChild(inputElement);
            divElement.appendChild(buttonElement);

            liElement.appendChild(spanElement);
            liElement.appendChild(strongElement);
            liElement.appendChild(divElement);

            moviesSectionUl.appendChild(liElement);
        }

        movieTextElement.value = '';
        hallNameTextElement.value = '';
        ticketPriceTextElement.value = '';
    }

    function archiveMovie(e){
        const movieElement = e.target.parentElement.parentElement;
        const ticketsSoldCount = movieElement.querySelector('input');
        const ticketPrice = Number(movieElement.querySelector('div > strong').textContent);
        
        if (ticketsSoldCount.value && Number(ticketsSoldCount.value) >= 0) {            
            const totalSum = ticketPrice * Number(ticketsSoldCount.value);

            const liElement = document.createElement('li');

            const spanElement = document.createElement('span');
            spanElement.textContent = movieElement.querySelector('span').textContent;

            const strongElement = document.createElement('strong');
            strongElement.textContent = `Total amount: ${totalSum.toFixed(2)}`;

            const buttonElement = document.createElement('button');
            buttonElement.textContent = 'Delete';
            buttonElement.addEventListener('click', deleteMovie);

            liElement.appendChild(spanElement);
            liElement.appendChild(strongElement);
            liElement.appendChild(buttonElement);

            archiveSectionUl.appendChild(liElement);
            movieElement.remove();
        }
    }

    function deleteMovie(e){
        const recordToDelete = e.target.parentElement;
        recordToDelete.remove();
    }

    function clearAllArchivedMovies(e) {
        Array.from(document.querySelector('#archive ul').children)
            .forEach(c => c.remove());
    }
}