import { html } from './../../node_modules/lit-html/lit-html.js';

export const catalogTemplate = (games) => html`
<section id="catalog-page">
    <h1>All Games</h1>
    ${games.length > 0
        ? html`${games.map(gameTemplate)}`
        : html`<h3 class="no-articles">No articles yet</h3>`
    }    
</section>
`;

const gameTemplate = (gameData) => html`
<div class="allGames">
    <div class="allGames-info">
        <img src=${gameData.imageUrl}>
        <h6>${gameData.category}</h6>
        <h2>${gameData.title}</h2>
        <a href="/details/${gameData._id}" class="details-button">Details</a>
    </div>
</div>
`;