import { validateResponse } from "./validations.js";

const baseUrl = 'http://localhost:3030/jsonstore/collections/myboard';
const endPoints ={
    post: `${baseUrl}/posts`,
    comment: `${baseUrl}/comments`
};


export async function getRequest(endpoint, topicId) {
    let url = endPoints[endpoint];
    
    if (topicId) {
        url = `${url}/${topicId}`;
    }    

    try {
        const response = await fetch(url);
        validateResponse(response);
        const data = await response.json();

        return data;
    } catch (error) {
        throw Error(error.message);
    }
}


export async function postRequest(endPoint, dataInputs) {
    let url = endPoints[endPoint];

    try {
        const options = {
            method: 'post',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(dataInputs)
        };
    
        const response = await fetch(url, options);
        validateResponse(response);
    
        return response.json();
    } catch (error) {
        throw Error(error.message);
    } 
}
