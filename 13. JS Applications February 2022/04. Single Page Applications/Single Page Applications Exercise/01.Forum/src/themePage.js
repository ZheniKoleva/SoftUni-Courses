import { createAuthorComment, createTopicDetails, createUserComments, createMessage } from './create.js';
import { getRequest, postRequest } from './requests.js';
import { validateInputData } from './validations.js';

const endPointComment = 'comment';
const endPointPost = 'post';
const homePage = document.querySelector('#homePage');
const themePage = document.querySelector('#themePage');

const divThemeTitle = themePage.querySelector('.theme-title');
const divAuthorComment = themePage.querySelector('.header');
const divUsersComment = themePage.querySelector('#user-comment');
const commentForm = themePage.querySelector('form');
commentForm.addEventListener('submit', createComment);
let topicId = '';

export async function loadTopicDetails(e) {
    topicId = e.currentTarget.dataset.id;

    try {
        const data = await getRequest(endPointPost, topicId);

        divThemeTitle.replaceWith(createTopicDetails(data));
        divAuthorComment.replaceWith(createAuthorComment(data));

        await loadTopicComments(topicId);

        homePage.style.display = 'none';
        themePage.style.display = 'block';
    } catch (error) {
        alert(error.message);
    }
}

async function loadTopicComments(topicId) {
    try {
        const data = await getRequest(endPointComment);
        const filtered = Object.values(data)
            .filter(x => x.topicId === topicId);

        if (!filtered.length) {
            const message = createMessage('There is no comments from other users to show yet!');
            divUsersComment.replaceChildren(message);
        } else {
            const comments = filtered
                .map(x => createUserComments(x));

            divUsersComment.replaceChildren(...comments);
        }
    } catch (error) {
        alert(error.message);
    }
}

export async function createComment(e) {
    e.preventDefault();

    const formData = new FormData(commentForm);
    const commentData = Object.fromEntries(formData);
    commentData.topicId = topicId;
    commentData.time = new Date().toLocaleString();

    try {
        validateInputData(commentData);
        commentForm.reset();

        await postRequest(endPointComment, commentData);

        loadTopicComments(topicId);

    } catch (error) {
        alert(error.message);
    }
}