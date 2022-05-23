import { html } from './../../node_modules/lit-html/lit-html.js';

export const profileTemplate = (token, memes) => html`
<section id="user-profile-page" class="user-profile">
    <article class="user-info">
        <img id="user-avatar-url" alt="user-profile" src="/images/${token.gender}.png">
        <div class="user-content">
            <p>Username: ${token.username}</p>
            <p>Email: ${token.email}</p>
            <p>My memes count: ${memes.length}</p>
        </div>
    </article>
    <h1 id="user-listings-title">User Memes</h1>
    <div class="user-meme-listings">
        ${memes.length > 0 
            ? html`${memes.map(userMemeTemplate)}`
            : html`<p class="no-memes">No memes in database.</p>`
        }
    </div>
</section>
`;

const userMemeTemplate = (memeData) => html`
<div class="user-meme">
    <p class="user-meme-title">${memeData.title}</p>
    <img class="userProfileImage" alt="meme-img" src=${memeData.imageUrl}>
    <a class="button" href="/details/${memeData._id}">Details</a>
</div>
`;
