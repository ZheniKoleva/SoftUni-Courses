function validate() { 
    let inputEmail = document.querySelector('#email');

    inputEmail.addEventListener('change', function(){
        let emailPattern = /([a-z]+)@([a-z]+)\.([a-z]+)/g;

        if (emailPattern.test(inputEmail.value)) {
            inputEmail.classList.remove('error');
        }else{
            inputEmail.classList.add('error');
        }
    });
}