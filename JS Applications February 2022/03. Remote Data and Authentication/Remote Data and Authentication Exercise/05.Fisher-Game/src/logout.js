const logoutNavElement = document.querySelector('#logout');
logoutNavElement.addEventListener('click', logoutUser);

async function logoutUser(e) { 
   e.preventDefault();

    const url = 'http://localhost:3030/users/logout';
    const userToken = JSON.parse(sessionStorage.getItem('token'));

    const options = {
        method: 'get',
        headers: {
            'X-Authorization': userToken.accessToken
        }
    };

    try {
        const response = await fetch(url, options);

        if (response.status == 204) {
            //sessionStorage.removeItem('token');
            sessionStorage.clear();
            alert('Logout successffully!');
            window.location.assign('./index.html');
        }

    } catch (error) {
        alert(error.message);
    }
}
