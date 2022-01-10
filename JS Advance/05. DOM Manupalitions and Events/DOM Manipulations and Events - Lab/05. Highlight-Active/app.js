function focused() {
    let area = document.querySelector('div');

    area.addEventListener('focus', function(e) {
        if (e.target.nodeName == 'INPUT') {
            e.target.parentElement.classList.add('focused');
        }
    }, true);

    area.addEventListener('blur', function (e) {
        e.target.parentElement.classList.remove('focused');
    }, true);
}