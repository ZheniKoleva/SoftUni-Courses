function create(words) {
    let toAdd = document.querySelector('#content');

    words.forEach(word => {
        let newElement = document.createElement('div');

        let paragraph = document.createElement('p');
        paragraph.textContent = word;
        paragraph.style.display = 'none';

        newElement.appendChild(paragraph);
        newElement.addEventListener('click', (e) => {
            e.target.querySelector('p').style.display = 'block';
        });

        toAdd.appendChild(newElement);
    });
}