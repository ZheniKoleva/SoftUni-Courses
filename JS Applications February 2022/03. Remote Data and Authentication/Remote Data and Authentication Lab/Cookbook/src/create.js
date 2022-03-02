const formElement = document.querySelector('form');
formElement.addEventListener('submit', createRecipe);

async function createRecipe(e) {
    e.preventDefault();

    const url = 'http://localhost:3030/data/recipes';
    const formData = new FormData(e.target);    
    const recipeData = Object.fromEntries(formData);
    const userToken = sessionStorage.getItem('token');

    try {
        ValidateRecipeData(recipeData); 

        const recipe = {
            name: recipeData.name,
            img: recipeData.img,
            ingredients: filterData(recipeData.ingredients),
            steps: filterData(recipeData.steps)
        };

        const options = {
            method: 'post',
            headers: {
                'Content-Type': 'apllication/json',
                'X-Authorization': userToken
            },
            body: JSON.stringify(recipe)
        };

        const response = await fetch(url, options);               

        if(response.status === 200) {
            alert('Recipe created successfully!');
            window.location = 'index.html';
        }else {
            const data = await response.json(); 
            throw new Error(data.message);
        }

    } catch (error) {
        window.location = 'index.html';
        alert(error.message);       
    }
}

function ValidateRecipeData(recipeData) {
    if(Object.values(recipeData).some(x => !x)) {
        throw new Error('All the fields must be filled!');
    }
}

function filterData(data) {
    return data
        .split('\n')
        .filter(x => x)
        .map(x => x.trim())
}

