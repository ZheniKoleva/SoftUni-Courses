function validate() {
    const inputElement = document.querySelector('#email');
    inputElement.addEventListener('change', validateEmail);

    function validateEmail(e){        
        const emailPattern = /([a-z]+)@([a-z]+)\.([a-z]+)/g;
        
        if (!emailPattern.test(inputElement.value)) {
            e.target.classList.add('error');
        }else{
            e.target.classList.remove('error');
        }
    }
}