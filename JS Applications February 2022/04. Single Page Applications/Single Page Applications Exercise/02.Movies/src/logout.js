import { toggleNavBar } from "./nav.js";
import { showHome } from "./homePage.js";
import { hasSession } from "./common.js";

export async function logout() {
    const url = 'http://localhost:3030/users/logout';
    const userToken = hasSession();

    const options = {
        method: 'get',
        headers: {
            'X-Authorization': userToken.accessToken
        }
    };

    try {
        const response = await fetch(url, options);

        if (response.status == 204) {
            sessionStorage.clear();
            alert('Logout successffully!'); 
            toggleNavBar();
            showHome();           
        }

    } catch (error) {
        alert(error.message);
    }
}