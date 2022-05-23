import { html } from './../../node_modules/lit-html/lit-html.js';
import { memeTemplate } from './memeTemplate.js';

export const allMemesTemplate = (memes) => html`
<section id="meme-feed">
    <h1>All Memes</h1>
    <div id="memes">
        ${memes.length > 0
            ? html`${memes.map(memeTemplate)}`
            : html`<p class="no-memes">No memes in database.</p>`
        }
	</div>
</section>
`;