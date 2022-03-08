const logoutBtn = document.querySelector('#logoutBtn');
logoutBtn.addEventListener('click', logoutUser);

async function logoutUser(e) {
    const url = 'http://localhost:3030/users/logout';
    const userToken = JSON.parse(sessionStorage.getItem('token')).accessToken;

    const options = {
        method: 'get',
        headers: {
            'X-Authorization': userToken
        }
    };

    try {
        const response = await fetch(url, options);

        if (response.status == 204) {
            sessionStorage.clear();
            alert('Logout successffully!');
            window.location.assign('home.html');
        }

    } catch (error) {
        alert(error.message);
    }
}
