function attachEvents() {
    document.querySelector('#btnLoadPosts').addEventListener('click', loadPosts);
    document.querySelector('#btnViewPost').addEventListener('click', viewPostAndComments);
}

async function loadPosts() {
    const selectSection = document.querySelector('#posts');
    selectSection.replaceChildren();
    const url = 'http://localhost:3030/jsonstore/blog/posts';

    const response = await fetch(url);
    const data = await response.json();

    Object.values(data)
        .forEach(x => {
            const optionElement = document.createElement('option');
            optionElement.setAttribute('value', x.id);
            optionElement.textContent = x.title;

            selectSection.append(optionElement);
        });
}

async function viewPostAndComments() {
    const selectedPostId = document.querySelector('#posts').value;
    const postUrl = `http://localhost:3030/jsonstore/blog/posts/${selectedPostId}`;

    const response = await fetch(postUrl);
    const post = await response.json();

    document.querySelector('#post-title').textContent = post.title.toUpperCase();
    document.querySelector('#post-body').textContent = post.body;

    const commentsUlElement = document.querySelector('#post-comments');
    commentsUlElement.replaceChildren();
    const commentsUrl = 'http://localhost:3030/jsonstore/blog/comments';

    const responseComments = await fetch(commentsUrl);
    const comments = await responseComments.json();

    Object.values(comments)
        .filter(x => x.postId === selectedPostId)
        .forEach(x => {
            const liElement = document.createElement('li');
            liElement.textContent = x.text;

            commentsUlElement.append(liElement);
        });
}

attachEvents();