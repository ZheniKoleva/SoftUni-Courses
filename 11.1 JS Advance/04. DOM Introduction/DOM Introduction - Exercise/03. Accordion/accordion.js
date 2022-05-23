function toggle() {
    let buttonCondition = document.querySelector('.button');
    let textToHideShow = document.querySelector('#extra');

    textToHideShow.style.display = buttonCondition.textContent === 'More' ? 'block': 'none';
   
    buttonCondition.textContent = buttonCondition.textContent === 'More' ? 'Less' : 'More';
}