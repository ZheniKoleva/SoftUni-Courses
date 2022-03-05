function attachEvents() {
    document.querySelector('#submit').addEventListener('click', sendMessage);
    document.querySelector('#refresh').addEventListener('click', loadMessages);
}

async function sendMessage() {
    const url = 'http://localhost:3030/jsonstore/messenger';
    const authorElement = document.querySelector('input[name="author"]');
    const textElement = document.querySelector('input[name="content"]');
    const messagesArea = document.querySelector('#messages');

    const data = {
        author: authorElement.value,
        content: textElement.value,
    };

    authorElement.value = '';
    textElement.value = '';

    const options = {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    };

    const response = await fetch(url, options);
    const newMessageData = await response.json();
    messagesArea.textContent += `${newMessageData.author}: ${newMessageData.content}\n`;
}

async function loadMessages() {
    const url = 'http://localhost:3030/jsonstore/messenger';
    const messagesArea = document.querySelector('#messages');

    const response = await fetch(url);
    const data = await response.json();
    messagesArea.textContent = Object.values(data)
        .map(x => `${x.author}: ${x.content}`)
        .join('\n');

    messagesArea.textContent += '\n';
}

attachEvents();    
