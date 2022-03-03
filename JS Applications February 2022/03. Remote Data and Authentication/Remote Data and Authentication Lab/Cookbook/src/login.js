const formElement = document.querySelector('form');
formElement.addEventListener('submit', logUser);

async function logUser(e) {
    e.preventDefault();
    
    const url = 'http://localhost:3030/users/login';
    const formData = new FormData(e.target);
    const userData = Object.fromEntries(formData);
    formElement.reset();

    try {
        validateUserInputData(userData);

        const user = {
            email: userData.email,
            password: userData.password
        };        
        
        const options = {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        };

        const response = await fetch(url, options); 
        const data = await response.json(); 

        if (response.status === 200) {
            sessionStorage.setItem('token', data.accessToken);           
            window.location = 'index.html';           
        }else {            
            throw new Error(data.message);
        }

    } catch (error) {
        window.location = 'login.html';
        alert(error);
    }
}

function validateUserInputData(userData) {

    if (Object.values(userData).some(x => !x)) {
        throw new Error('Please, fill all the fields!');
    }
}


    
