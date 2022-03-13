import { loadTopics } from "./homePage.js";

document.querySelector('a').addEventListener('click', solve);

const homePage = document.querySelector('#homePage');
const themePage = document.querySelector('#themePage');

async function solve() {
    await loadTopics();

    homePage.style.display = 'block';
    themePage.style.display = 'none';
}

solve();


