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

function validateYearAndPrice(year, price) {
    if(Number(year) < 0) {
        throw new Error('Year should be a positive number!')
    }

    if(Number(price) < 0) {
        throw new Error('Price should be a positive number!')
    }
}

export default {
    validateInputs,
    validatePasswords,
    validateYearAndPrice   
}