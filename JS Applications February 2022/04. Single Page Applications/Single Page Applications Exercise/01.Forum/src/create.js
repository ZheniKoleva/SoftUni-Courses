//Some of the variables are not used, but they are created for readability of code

export function createTopicElement(topicData) {
    const divWrapper = createHTMLElement('div', '', '', { class: 'topic-name-wrapper' });
    divWrapper.dataset.id = topicData._id;     
    const divTopicName = createHTMLElement('div', '', divWrapper, { class: 'topic-name' });
    const aElement = createHTMLElement('a', '', divTopicName, { href: '#' }, { class: 'normal' });
    const h2Element = createHTMLElement('h2', topicData.topicName, aElement);
    const divColumns = createHTMLElement('div', '', divTopicName, { class: 'columns' });
    const divInside = createHTMLElement('div', '', divColumns);
    const pElement = createHTMLElement('p', 'Date: ', divInside);
    const timeElement = createHTMLElement('time', topicData.time, pElement);
    const divNickame = createHTMLElement('div', '', divInside, { class: 'nick-name' });
    const pUsername = createHTMLElement('p', 'Username: ', divNickame);
    const span = createHTMLElement('span', topicData.username, pUsername);

    return divWrapper;
}

export function createTopicDetails(topicData) {    
    const divThemeWrapper = createHTMLElement('div', '', '', {class: 'theme-name-wrapper'});
    const divThemeName = createHTMLElement('div', '', divThemeWrapper, {class: 'theme-name'});
    const h2Element = createHTMLElement('h2', topicData.topicName, divThemeName);

    return divThemeWrapper;
}

export function createAuthorComment(topicData) {
    const divHeader = createHTMLElement('div', '', '', {class: 'header'});
    const imgElement = createHTMLElement('img', '', divHeader, {src: './static/profile.png'}, {alt: 'avatar'})
    const pElement = createHTMLElement('p', '', divHeader);
    const strongElement = createHTMLElement('strong', `${topicData.username}`, pElement);  
    const textNode = document.createTextNode(' posted on '); 
    pElement.append(textNode); 
    const timeElement = createHTMLElement('time', topicData.time, pElement);

    const pText = createHTMLElement('p', topicData.postText, divHeader, {class: 'post-content'});

    return divHeader;
}

export function createUserComments(commentData) {
    const divWrapper = createHTMLElement('div', '', '', {class: 'topic-name-wrapper'});
    const divTopicName = createHTMLElement('div', '', divWrapper, {class: 'topic-name'});
    const pElement = createHTMLElement('p', '', divTopicName);
    const strongElement = createHTMLElement('strong', `${commentData.username}`, pElement);
    const textNode = document.createTextNode(' commented on '); 
    pElement.append(textNode); 
    const timeElement = createHTMLElement('time', commentData.time, pElement);
    const divText = createHTMLElement('div', '', divTopicName, {class: 'post-content'});
    const pText = createHTMLElement('p', commentData.postText, divText);

    return divWrapper;
}

export function createMessage(messageToShow) {
    return createHTMLElement('p', `${messageToShow}`, '', { class: 'topic-name-wrapper' });
}

function createHTMLElement(type, textContent, parent, ...attributes) {
    const element = document.createElement(type);

    if (textContent) {
        element.textContent = textContent;
    }

    if (attributes.length > 0) {
        attributes.forEach(x => {
            const [key, value] = Object.entries(x)[0];
            element.setAttribute(key, value);
        });
    }

    if (parent) {
        parent.append(element);
    }

    return element;
}
