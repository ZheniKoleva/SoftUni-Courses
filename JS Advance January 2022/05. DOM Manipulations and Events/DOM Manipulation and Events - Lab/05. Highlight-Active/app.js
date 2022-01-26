function focused() {
    const divElement = document.querySelector('div');
    divElement.addEventListener('focus', highlightActive, true);
    divElement.addEventListener('blur', unCheckActive, true);

    function highlightActive(e){
        if (e.target.nodeName == 'INPUT') {
            e.target.parentElement.classList.add('focused');
        }
    }

    function unCheckActive(e){
        e.target.parentElement.classList.remove('focused');        
    }
}