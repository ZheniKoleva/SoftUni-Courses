async function solution() {
    const url = 'http://localhost:3030/jsonstore/advanced/articles/list';

    const response = await fetch(url);
    const articles = await response.json();

    const mainSection = document.querySelector('#main');

    Object.values(articles)
        .forEach(x => {           
            const article = loadSingleArticle(x);
            mainSection.append(article);
        });
}

function loadSingleArticle(article) {
    const divElement = createHTMLElement('div', undefined, undefined, 'accordion');
    const divHead = createHTMLElement('div', undefined, divElement, 'head');
    const spanTitle = createHTMLElement('span', article.title, divHead);
    const button = createHTMLElement('button', 'More', divHead, 'button');
    button.setAttribute('id', article._id);
    button.setAttribute('data-isLoaded', false);
    button.addEventListener('click', () => showArticleContent(divElement));
 
    const divExtra = createHTMLElement('div', undefined, divElement, 'extra');
    const pElement = createHTMLElement('p', undefined, divExtra);
 
    return divElement;
}
 
async function showArticleContent(articleElement) {
    const button = articleElement.querySelector('button');
    const isContentLoaded = button.dataset.isloaded;
    const divToShow = articleElement.querySelector('.extra');
    const pElement = divToShow.querySelector('p');
 
    if (isContentLoaded === 'false') {
        const url = `http://localhost:3030/jsonstore/advanced/articles/details/${button.id}`;

        const response = await fetch(url);
        const data = await response.json();

        pElement.textContent = data.content;

        button.dataset.isloaded = true;
    }
 
    divToShow.style.display = button.textContent === 'More'
        ? 'block'
        : 'none';
 
    button.textContent = button.textContent === 'More'
        ? 'Less'
        : 'More';
}
 
function createHTMLElement(type, textContent, parent, className) {
    const element = document.createElement(type);
 
    if (textContent) {
        element.textContent = textContent;
    }
 
    if (className) {
        element.classList.add(className);
    }
 
    if (parent) {
        parent.appendChild(element);
    }
 
    return element;
}
 
solution();

// async function solution() {
//     const url = 'http://localhost:3030/jsonstore/advanced/articles/list';

//     const response = await fetch(url);
//     const articles = await response.json();

//     const mainSection = document.querySelector('#main');

//     Object.values(articles)
//         .forEach(async (x) => {
//             const url = `http://localhost:3030/jsonstore/advanced/articles/details/${x._id}`;
//             const response = await fetch(url);
//             const data = await response.json(); 

//             const article = loadSingleArticle(x, data.content);
//             mainSection.append(article);
//         });
// }


// function loadSingleArticle(article, content) { 
//     const divElement = createHTMLElement('div', undefined, undefined, 'accordion');
//     const divHead = createHTMLElement('div', undefined, divElement, 'head');
//     const spanTitle = createHTMLElement('span', article.title, divHead);
//     const button = createHTMLElement('button', 'More', divHead, 'button');
//     button.setAttribute('id', article._id);    
//     button.addEventListener('click', () => showArticleContent(divElement));

//     const divExtra = createHTMLElement('div', undefined, divElement, 'extra');
//     const pElement = createHTMLElement('p', content, divExtra);

//     return divElement;
// }

// async function showArticleContent(parent) {
//     const button = parent.querySelector('.button');    
//     const divToShow = parent.querySelector('.extra');
    
//     divToShow.style.display = button.textContent === 'More'
//         ? 'block'
//         : 'none';

//     button.textContent = button.textContent === 'More'
//         ? 'Less'
//         : 'More';
// }

// function createHTMLElement(type, textContent, parent, className) {
//     const element = document.createElement(type);

//     if (textContent) {
//         element.textContent = textContent;
//     }

//     if (className) {
//         element.classList.add(className);
//     }

//     if (parent) {
//         parent.appendChild(element);
//     }

//     return element;
// }

// solution();