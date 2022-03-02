const formElement = document.querySelector('form');
formElement.addEventListener('submit', registerUser);

async function registerUser(e) {
    e.preventDefault();

    const url = 'http://localhost:3030/users/register';
    const formData = new FormData(e.target);
    const userData = Object.fromEntries(formData);
    formElement.reset();

    try {
        ValidateUserInputData(userData);

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
            console.log(data.accessToken);
            sessionStorage.setItem('token', data.accessToken);
            alert('User registered successfully!');
            window.location = 'login.html';           
        }else {            
            throw new Error(data.message);
        }

    } catch (error) {
        window.location = 'register.html';
        alert(error);
    }
}

function ValidateUserInputData(userData) {

    if (Object.values(userData).some(x => !x)) {
        throw new Error('Please, fill all the fields!');
    }

    if (userData.password !== userData.rePass) {
        throw new Error('Passwords should match!');
    }
}
