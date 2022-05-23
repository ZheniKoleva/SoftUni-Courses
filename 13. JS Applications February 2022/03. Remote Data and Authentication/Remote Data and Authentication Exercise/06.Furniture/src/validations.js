export function validateUserInputData(userData) {

    if (Object.values(userData).some(x => !x)) {
        throw new Error('Please, fill all the fields!');
    }  
}

export function validatePasswords(userData) {
    if (userData.password !== userData.rePass) {
        throw new Error('Passwords should match!');
    }
}

export function validateResponse(response) {
    if(response.status === 403) {
        throw new Error('Invalid credentials!');
    }
    
    if(response.status !== 200) {
        throw new Error('Something went wrong! Please, try again.');
    }
}

export function validateFurnitureInputData(furnitureData) {
    if (Object.values(furnitureData).some(x => !x)) {
        throw new Error('Please, fill all the fields!');
    }  
}

