window.addEventListener('load', getAllRecipies);

function getAllRecipies() {
    const mainSection = document.querySelector('main');
    mainSection.firstElementChild.remove();
    const url = 'http://localhost:3030/jsonstore/cookbook/recipes';

    fetch(url)
        .then(response => validateResponse(response))
        .then(data => visualizeRecipies(data))
        .catch(error => alert(error.message));
   
    function visualizeRecipies(data) {
        Object.values(data)
            .map(x => createArticleElements(x))
            .forEach(x => mainSection.appendChild(x));
    }
}

function showRecipeDetails(element, recipeId) { 
    const url = `http://localhost:3030/jsonstore/cookbook/details/${recipeId}`;

    fetch(url)
        .then(response => validateResponse(response))
        .then(data => visualizeRecipeDetails(data))
        .catch(error => alert(error.message));

    function visualizeRecipeDetails(data) {
        const article = createDetailsElements(data);
        article.addEventListener('click', () => hideRecipeDetails(article, data));

        element.replaceWith(article);
    }
}

function hideRecipeDetails(element, data) {
    const article = createArticleElements(data);

    element.replaceWith(article);
}

function validateResponse(response) {
    if (response.status == 404) {
        throw new Error(`Error: ${response.status} (Not Found)`);
    }

    return response.json();
}

function createArticleElements(currentRecipeInfo) {    
    const articleElement = createHTMLElements('article', undefined, 'preview', undefined);
    const divElement = createHTMLElements('div', undefined, 'title', articleElement);
    const h2Element = createHTMLElements('h2', currentRecipeInfo.name, undefined, divElement);
    const divPhoto = createHTMLElements('div', undefined, 'small', articleElement);
    const imgElement = createHTMLElements('img', currentRecipeInfo.img, undefined, divPhoto);
        
    articleElement.addEventListener('click', () => showRecipeDetails(articleElement, currentRecipeInfo._id));

    return articleElement;
}

function createDetailsElements(recipeInfo) {
    const articleElement = createHTMLElements('article');
    const h2Element = createHTMLElements('h2', recipeInfo.name, 'undefined', articleElement);
    
    const divCommonInfo = createHTMLElements('div', undefined, 'band', articleElement);
    const divImgInfo = createHTMLElements('div', undefined, 'thumb', divCommonInfo);
    const imgElement = createHTMLElements('img', recipeInfo.img, undefined, divImgInfo);
    const divIngredients = createHTMLElements('div', undefined, 'ingredients', divCommonInfo);
    const h3Ingredients = createHTMLElements('h3', 'Ingredients:', undefined, divIngredients);
    const ulElement = createHTMLElements('ul', undefined, undefined, divIngredients);
    recipeInfo.ingredients
        .forEach(x => createHTMLElements('li', x, undefined, ulElement));
    
    const divDescription = createHTMLElements('div', undefined, 'description', articleElement);
    const h3Preparation = createHTMLElements('h3', 'Preparation', undefined, divDescription);
    recipeInfo.steps
        .forEach(x => createHTMLElements('p', x, undefined, divDescription));

    return articleElement;
}

function createHTMLElements(type, textContent, className, parent) {
    const element = document.createElement(type);

    if(type === 'img') {
        element.setAttribute('src', textContent);

    }else if (textContent) {
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

 // try {
    //     const response = await fetch(url); 
    //     const recipiesData = await response.json();

    //     if (!response.ok) {
    //         throw new Error(`Error: ${response.status} (Not Found)`);
    //     }

    //     Object.values(recipiesData)
    //         .map(x => createElements(x))
    //         .forEach(x => mainSection.appendChild(x));

    // } catch (error) {
    //     console.log(error.message)
    // } 
