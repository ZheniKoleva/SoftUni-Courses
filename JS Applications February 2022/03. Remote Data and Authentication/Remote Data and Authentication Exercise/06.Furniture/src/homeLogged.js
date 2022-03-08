import * as validations from './validations.js';
import { createRow } from './create.js';

const createForm = document.querySelector('#create-form');
createForm.addEventListener('submit', addFurniture);

const buyBtn = document.querySelector('#buyBtn');
buyBtn.addEventListener('click', buyFurniture);

const ordersDiv = document.querySelector('.orders');
const allOrdersBtn = ordersDiv.querySelector('button');
allOrdersBtn.addEventListener('click', getOrders);
const [boughtFurnitureSpan, totalPriceSpan] = ordersDiv.querySelectorAll('p > span');
boughtFurnitureSpan.textContent = 'You have not buy anything yet!'
totalPriceSpan.textContent = '0 $';

const tableBody = document.querySelector('#table-body');

window.onload = loadFurniture;

async function loadFurniture() {
    const url = 'http://localhost:3030/data/furniture';

    try {
        const response = await fetch(url);
        validations.validateResponse(response);

        const data = await response.json();

        Object.values(data)
            .forEach(x => {
                const row = createRow(x);
                tableBody.append(row);
            });

    } catch (error) {
        alert(error.message);
    }
}

async function addFurniture(e) {
    e.preventDefault();

    const url = 'http://localhost:3030/data/furniture';
    const dataInput = new FormData(createForm);
    const furnitureData = Object.fromEntries(dataInput);
    const userToken = JSON.parse(sessionStorage.token).accessToken;

    try {
        validations.validateFurnitureInputData(furnitureData);
        createForm.reset();

        const options = {
            method: 'post',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': userToken
            },
            body: JSON.stringify(furnitureData)
        };

        const response = await fetch(url, options);
        validations.validateResponse(response);

        const data = await response.json();

        const newRowElement = createRow(data);
        tableBody.append(newRowElement);

    } catch (error) {
        alert(error.message);
    }
}

async function buyFurniture() {
    const url = 'http://localhost:3030/data/orders';
    const userToken = JSON.parse(sessionStorage.token).accessToken;

    const chosenFurniture = [...tableBody.querySelectorAll('input[type=checkbox]:checked')]
        .map(x => {
            x.checked = false;
            return x.parentElement.parentElement;
        })
        .map(x => {
            const [imgCol, nameCol, priceCol, factorCol] = x.children;

            return {
                img: imgCol.firstElementChild.src,
                name: nameCol.firstElementChild.textContent,
                price: priceCol.firstElementChild.textContent,
                factor: factorCol.firstElementChild.textContent
            };
        });

    if (!chosenFurniture.length) {
        alert('You have not buy anything!');
        return;
    }

    for (const furniture of chosenFurniture) {
        try {
            const options = {
                method: 'post',
                headers: {
                    'Content-Type': 'application/json',
                    'X-Authorization': userToken
                },
                body: JSON.stringify(furniture)
            };

            await fetch(url, options);

        } catch (error) {
            alert(error.message);
        }
    }


}


async function getOrders(e) {
    const url = `http://localhost:3030/data/orders`;
    const userId = JSON.parse(sessionStorage.token).userId;

    try {
        const response = await fetch(url);
        validations.validateResponse(response);

        const data = await response.json();

        const userBought = data.filter(x => x._ownerId == userId);
        const names = userBought.map(x => x.name).join(', ');
        const totalPrice = userBought.reduce((a, b) => a + Number(b.price), 0);

        boughtFurnitureSpan.textContent = names;
        totalPriceSpan.textContent = `${totalPrice} $`;

    } catch (error) {
        alert(error.message);
    }
}