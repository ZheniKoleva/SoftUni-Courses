function validateInputs(data) {
    if (Object.values(data).some(x => !x)) {
        throw new Error('Please, fill all the fields!');
    }
}

function validatePasswords(password, repeatPassword) {
    if (password !== repeatPassword) {
        throw new Error('Passwords should match!');
    }
}


export default {
    validateInputs,
    validatePasswords    
}