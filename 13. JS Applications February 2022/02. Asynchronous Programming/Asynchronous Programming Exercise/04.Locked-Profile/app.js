function lockedProfile() {
    document.querySelector('div.profile').remove();
    const url = `http://localhost:3030/jsonstore/advanced/profiles`;

    fetch(url)
        .then(response => response.json())
        .then(data => loadData(data))
        .catch(error => alert(error.message));
}

function loadData(usersData) {
    const mainElement = document.querySelector('#main');
    Object.values(usersData)
        .forEach((x, i) => {
            const profile = loadProfile(x, ++i);
            mainElement.appendChild(profile)
        });      
}

function loadProfile(userData, index) {
    const mainDiv = createHTMLElement('div');
    mainDiv.classList.add('profile');
    const imgElement = createHTMLElement('img', undefined, mainDiv);
    imgElement.classList.add('userIcon');
    const lockLabel = createHTMLElement('label', 'lock', mainDiv);
    const lockInput = createInputElement('radio', `user${index}Locked`, 'lock', true, mainDiv);
    const unlockLabel = createHTMLElement('label', 'unlock', mainDiv);
    const unlockInput = createInputElement('radio', `user${index}Locked`, 'unlock', false, mainDiv);
    const hrElement1 = createHTMLElement('hr', undefined, mainDiv);
    const usernameLabel = createHTMLElement('label', 'Username', mainDiv);
    const textInput = createInputElement('text', `user${index}Username`, userData.username, true, mainDiv);
    const hiddenDiv = createHTMLElement('div', undefined, mainDiv);
    hiddenDiv.setAttribute('id', `user${index}HiddenFields`);
    hiddenDiv.style.display = 'none';
    const hrElement2 = createHTMLElement('hr', undefined, hiddenDiv);
    const emailLabel = createHTMLElement('label', 'Email:', hiddenDiv);
    const emailInput = createInputElement('email', `user${index}Email`, userData.email, true, hiddenDiv);
    const ageLabel = createHTMLElement('label', 'Age:', hiddenDiv);
    const ageInput = createInputElement('email', `user${index}Age`, userData.age, true, hiddenDiv);
    const button = createHTMLElement('button', 'Show more', mainDiv);
    button.addEventListener('click', toggleUserData);

    return mainDiv;
}

function toggleUserData(e) {
    const parent = e.target.parentElement;
    const radioButton = parent.querySelector('input[type="radio"]:checked');
    const divToToggle = parent.querySelector('div');

    if (radioButton.value === 'unlock') {
        divToToggle.style.display = divToToggle.style.display === 'block'
            ? 'none'
            : 'block';

        e.target.textContent = e.target.textContent === 'Show more'
            ? 'Less'
            : 'Show more';
    }
}

function createHTMLElement(type, textContent, parent){
    const element = document.createElement(type);

    if (type === 'img') {
        element.setAttribute('src', "./iconprofile2.png");
    }

    if (textContent) {
        element.textContent = textContent;
    }

    if (parent) {
        parent.appendChild(element);
    }

    return element;
}

function createInputElement(attrType, attrName, attrValue, isChosenValue, parent){ 
    const element = document.createElement('input');
    element.setAttribute('type', attrType);
    element.setAttribute('name', attrName);
    element.setAttribute('value', attrValue);

    if(isChosenValue) {
        if(attrType === 'radio') {
            element.checked = true;
        }else {
            element.disabled = true;
            element.readOnly = true;
        }
    }

    parent.appendChild(element);

    return element;
}