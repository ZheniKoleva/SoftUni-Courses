export function validateResponse(response) {
    if(response.status !== 200) {
        throw new Error('Something went wrong! Please try again!');
    }
}

export function validateInputData(data) {
    if(Object.values(data).some(x => !x)) {
        throw new Error('Please, fill all the fields!');
    }
}