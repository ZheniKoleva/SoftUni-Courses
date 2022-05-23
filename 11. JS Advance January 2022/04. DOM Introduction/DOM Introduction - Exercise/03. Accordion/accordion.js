function toggle() {
    const button = document.querySelector('.head .button');
    const textToShowHide = document.querySelector('#extra');
    
    textToShowHide.style.display = button.textContent == 'More'
    ? 'block'
    : 'none';   
    
    button.textContent = button.textContent == 'More'
    ? 'Less'
    : 'More';
}