import { validateResponse } from "./validations.js";

const baseUrl = 'http://localhost:3030/jsonstore/collections/books';

async function getRequest() {
    const response = await fetch(baseUrl);
    validateResponse(response);
    const data = await response.json();

    const booksData = Object.entries(data)
        .map(([key, value]) => ({
            title: value.title,
            author: value.author,
            _id: key
        }));

    return booksData;
}

async function postRequest(bookData) {
    const options = {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(bookData)
    }

    const response = await fetch(baseUrl, options);
    validateResponse(response);
}

async function putRequest(bookId, bookNewData) {
    const url = `${baseUrl}/${bookId}`;

    const options = {
        method: 'put',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(bookNewData)
    }

    const response = await fetch(url, options);
    validateResponse(response);
}

async function deleteRequest(bookId) {
    const url = `${baseUrl}/${bookId}`;

    const response = await fetch(url, { method: 'delete' });
    validateResponse(response);
}

const request = {
    getRequest,
    postRequest,
    putRequest,
    deleteRequest
};

export default request;