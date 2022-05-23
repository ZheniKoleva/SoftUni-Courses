export function validateResponse(response) {
    if(response.status === 403) {
        throw new Error('Invalid credentials!');
    }

    if(response.status !== 200) {
        throw new Error('Something went wrong! Please, try again!');
    }
}

export function validateInputData(inputData) {
    if(Object.values(inputData).some(x => !x)) {
        throw new Error('Please fill all the fields in the form!');
    }
}

export function validatePasswords(password, repeatPassword) {
    const passwordLength = 6;

    if(password.length < passwordLength || repeatPassword.length < passwordLength) {
        throw new Error('Password length should be at least 6 scharacters long!');
    }
    
    if(password !== repeatPassword) {
        throw new Error('Passwords should match!');
    }
}


