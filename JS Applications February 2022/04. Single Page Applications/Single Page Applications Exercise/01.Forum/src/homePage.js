import { createTopicElement, createMessage } from "./create.js";
import { loadTopicDetails } from "./themePage.js"
import { getRequest, postRequest } from "./requests.js";
import { validateInputData } from "./validations.js";

const endPoint = 'post';
const homePage = document.querySelector('#homePage');

homePage.querySelector('.cancel').addEventListener('click', cancelTopicPost);
homePage.querySelector('.public').addEventListener('click', createTopic);

const topicContainer = homePage.querySelector('.topic-container');
const topicForm = homePage.querySelector('form');

export async function loadTopics() {
    try {
        const data = await getRequest(endPoint);

        if (!Object.keys(data).length) {            
            topicContainer.append(createMessage('There is no topics to show yet!'));
        } else {
            const topics = Object.values(data).map(x => {
                const theme = createTopicElement(x);
                theme.addEventListener('click', loadTopicDetails);

                return theme;
            });

            topicContainer.replaceChildren(...topics);
        }
    } catch (error) {
        alert(error.messsage)
    }

}

export async function createTopic(e) {
    e.preventDefault();

    const formData = new FormData(topicForm);
    const formInputs = Object.fromEntries(formData);
    formInputs.time = new Date().toLocaleString();

    try {
        validateInputData(formInputs);
        topicForm.reset();
        await postRequest(endPoint, formInputs);
        loadTopics();

    } catch (error) {
        alert(error.message);
    }
}

export async function cancelTopicPost(e) {
    e.preventDefault();
    topicForm.reset();
}
