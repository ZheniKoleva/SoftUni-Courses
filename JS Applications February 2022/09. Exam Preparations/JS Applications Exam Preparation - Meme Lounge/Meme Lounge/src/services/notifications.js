const errorBox = document.querySelector('#errorBox');

export function showNotification(message) {         
    errorBox.querySelector('span').textContent = message;
    errorBox.style.display = 'block';

    setTimeout(() => errorBox.style.display = 'none', 3000);   
}

export default {
    showNotification
}