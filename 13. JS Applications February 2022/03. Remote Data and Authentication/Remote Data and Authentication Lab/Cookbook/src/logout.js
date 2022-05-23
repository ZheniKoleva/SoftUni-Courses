async function logoutUser(e) {
    e.preventDefault(); 
    
    const url = 'http://localhost:3030/users/logout';
    const userToken = sessionStorage.getItem('token');

    const options = {
        method: 'get',
        headers: {
            'X-Authorization': userToken
        }
    };

    const response = await fetch(url, options);

    if (response.status == 204) {
        sessionStorage.removeItem('token');
        //sessionStorage.clear();
        window.location = 'index.html';
    }
}
