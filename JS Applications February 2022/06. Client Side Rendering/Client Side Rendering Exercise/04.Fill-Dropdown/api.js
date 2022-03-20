const baseUrl = 'http://localhost:3030/jsonstore/advanced/dropdown';

export async function makeRequest(newOptionData) {
    let options = {};

    if (newOptionData) {
        options = {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newOptionData)
        }
    }

    const response = await fetch(baseUrl, options); 
    validateResponse(response);
    const data = await response.json();

    return newOptionData ? data : Object.values(data);
} 

function validateResponse(response) {
    if(!response.ok) {
        throw new Error('Something went wrong! Please, try again!');
    }
}