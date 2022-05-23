window.onload = solve();

async function solve() { 
    const userNavSection = document.querySelector('#user');
    userNavSection.style.display = 'none'; 

    const guestNavSection = document.querySelector('#guest');
    guestNavSection.style.display = 'inline-block'; 

    const homeNavElement = document.querySelector('#home');
    homeNavElement.classList.remove('active');

    const regNavElement = document.querySelector('#guest > #register');
    regNavElement.classList.add('active');       

    const form = document.querySelector('#register-view > #register');
    form.addEventListener('submit', registerUser);
}

async function registerUser(e) {
    e.preventDefault();

    const url = 'http://localhost:3030/users/register';
    const formElement = e.target;
    const formData = new FormData(formElement);
    const userData = Object.fromEntries(formData);

    try {
        validateUserInputData(userData);
        formElement.reset();

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
        validateResponse(response);
        const data = await response.json();

        const token = {
            accessToken: data.accessToken,
            email: data.email,
            userId: data._id
        }

        sessionStorage.setItem('token', JSON.stringify(token));           
        alert('User registered successfully!');
        
        window.location.assign('./index.html'); 

    } catch (error) {
        window.location.assign('./register.html');
        alert(error);
    }
}

function validateUserInputData(userData) {

    if (Object.values(userData).some(x => !x)) {
        throw new Error('Please, fill all the fields!');
    }

    if (userData.password !== userData.rePass) {
        throw new Error('Passwords should match!');
    }
}

function validateResponse(response) {
    if(response.status !== 200) {
        throw new Error('Something went wrong! Please, try again.');
    }
}