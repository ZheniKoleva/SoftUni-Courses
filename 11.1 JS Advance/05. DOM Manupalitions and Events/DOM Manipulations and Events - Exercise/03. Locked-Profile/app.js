function lockedProfile() {
    Array.from(document.querySelectorAll('.profile button'))
        .forEach(b => b.addEventListener('click', showHideData));

    function showHideData(e) {
        let button = e.target;
        let parent = button.parentElement;
        let elementToShowHide = parent.querySelector('div');
        let radioButton = parent.querySelector('input[type="radio"]:checked');

        // if (buttonText === 'Show more' && radioButton.value === 'unlock') {
        //     elementToShowHide.style.display = 'block';
        //     e.target.textContent = 'Hide it';

        // } else if(buttonText === 'Hide it' && radioButton.value ==='unlock'){
        //     elementToShowHide.style.display = 'none';
        //     e.target.textContent = 'Show more';
        // }

        if (radioButton.value === 'unlock') {
            elementToShowHide.style.display = elementToShowHide.style.display === 'block'
                ? 'none'
                : 'block';

            button.textContent = button.textContent === 'Show more'
                ? 'Hide it'
                : 'Show more';

        }
    }
}