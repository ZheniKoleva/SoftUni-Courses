window.onload = solve();

async function solve() {
    const userNavSection = document.querySelector('#user'); 
    userNavSection.style.display = 'none';

    const guestNavSection = document.querySelector('#guest');
    guestNavSection.style.display = 'inline-block';

    const homeNavElement = document.querySelector('#home');
    homeNavElement.classList.remove('active');

    const loginNavElement = document.querySelector('#guest > #login');
    loginNavElement.classList.add('active');   

    const formElement = document.querySelector('#login-view > #login');
    formElement.addEventListener('submit', logUser);
}

async function logUser(e) {
    e.preventDefault();
    
    const url = 'http://localhost:3030/users/login';
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
        };

        sessionStorage.setItem('token', JSON.stringify(token));            
        alert('You logged in successffully!');
        window.location.assign('./index.html'); 
       
    } catch (error) {
        window.location.assign('./login.html');        
        alert(error);
    }
}

function validateUserInputData(userData) {

    if (Object.values(userData).some(x => !x)) {
        throw new Error('Please, fill all the fields!');
    }
}

function validateResponse(response) {
    if (response.status !== 200) {
        throw new Error('Invalid credentials!');
    } 
}