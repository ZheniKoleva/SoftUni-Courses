import { hasSession } from "./common.js";

const navBarElements = [...document.querySelectorAll('.nav-link')];
const usersNav = navBarElements.filter(x => x.classList.contains('user'));
const guestsNav = navBarElements.filter(x => x.classList.contains('guest'));

export function toggleNavBar() {
    const session = hasSession();
    
    if(session) {
        const userEmail = session.email;
        usersNav.find(x => x.id === 'greeting').textContent = `Welcome, ${userEmail}`;

        usersNav.forEach(x => x.style.display = 'block');
        guestsNav.forEach(x => x.style.display = 'none');              
    }else {
        usersNav.forEach(x => x.style.display = 'none');
        guestsNav.forEach(x => x.style.display = 'block');     
    }
}