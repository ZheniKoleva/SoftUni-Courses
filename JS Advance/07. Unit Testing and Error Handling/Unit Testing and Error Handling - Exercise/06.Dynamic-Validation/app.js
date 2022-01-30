function validate() {
    const inputEmailElement = document.querySelector('#email');
    inputEmailElement.addEventListener('change', validateInput);

    function validateInput(e){
        const emailPattern = /^[a-z]+\@[a-z]+\.[a-z]+$/;

        if (!emailPattern.test(inputEmailElement.value)) {
            inputEmailElement.classList.add('error');
        }else {
            inputEmailElement.classList.remove('error');
        }
    }
}