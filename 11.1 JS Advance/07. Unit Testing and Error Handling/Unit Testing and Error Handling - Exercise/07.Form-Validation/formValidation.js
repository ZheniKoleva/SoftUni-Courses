function validate() {
    const submitButton = document.querySelector('#submit');
    submitButton.addEventListener('click', validateInput);

    const companyElement = document.querySelector('#company');
    companyElement.addEventListener('change', toggleCompanyInfo);

    function validateInput(e){
       e.preventDefault();
        const userNamePattern = /^[A-Za-z\d]{3,20}$/;
        const emailPattern = /^.*@.*\..*$/;
        const passwordPattern = /^[\w]{5,15}$/;
        const companyNumberPattern = /^\d{4}$/;

        const usernameElement = document.querySelector('#username');
        const isUserNameValid = userNamePattern.test(usernameElement.value);
        changeStyle(usernameElement, isUserNameValid);

        const emailElement = document.querySelector('#email');
        const isEmailValid = emailPattern.test(emailElement.value);
        changeStyle(emailElement, isEmailValid);

        const passwordElement = document.querySelector('#password');
        const isPasswordValid = passwordPattern.test(passwordElement.value);       

        const confirmPasswordElement = document.querySelector('#confirm-password');
        const arePasswordsEqual = isPasswordValid && passwordElement.value === confirmPasswordElement.value;
        changeStyle(passwordElement, arePasswordsEqual);
        changeStyle(confirmPasswordElement, arePasswordsEqual);

        const companyElement = document.querySelector('#company');        
        const isCheckBoxChecked = companyElement.checked;
        let isValidCompanyNumber = false;

        if (isCheckBoxChecked) {
            const companyNumberElement = document.querySelector('#companyNumber');
            isValidCompanyNumber = companyNumberPattern.test(companyNumberElement.value)
            changeStyle(companyNumberElement, isValidCompanyNumber);
        }

        const resultDivElement = document.querySelector('#valid');
        const requiredFields = [isUserNameValid, isEmailValid, arePasswordsEqual];
        const areRequiredFieldsValid = requiredFields.every(x => x);

        resultDivElement.style.display = ((isCheckBoxChecked && isValidCompanyNumber && areRequiredFieldsValid)
            || (areRequiredFieldsValid && !isCheckBoxChecked))
            ? 'block'
            : 'none';

        function changeStyle(element, isValidInput){
            if (isValidInput) {
                element.style.border = 'none';
            } else {
                element.style.borderColor = 'red';
            }
        }
    }

    function toggleCompanyInfo(e){
        const companyInfoElement = document.querySelector('#companyInfo');

        companyInfoElement.style.display = e.target.checked ? 'block' : 'none';
    }
}
