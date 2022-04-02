import { html } from './../../node_modules/lit-html/lit-html.js';

export const editTemplate = (gameData, submitHandler) => html`
<section id="edit-page" class="auth">
    <form id="edit" @submit=${submitHandler}>
        <div class="container">

            <h1>Edit Game</h1>
            <label for="leg-title">Legendary title:</label>
            <input type="text" id="title" name="title" .value=${gameData.title}>

            <label for="category">Category:</label>
            <input type="text" id="category" name="category" .value=${gameData.category}>

            <label for="levels">MaxLevel:</label>
            <input type="number" id="maxLevel" name="maxLevel" min="1" .value=${gameData.maxLevel}>

            <label for="game-img">Image:</label>
            <input type="text" id="imageUrl" name="imageUrl" .value=${gameData.imageUrl}>

            <label for="summary">Summary:</label>
            <textarea name="summary" id="summary" .value=${gameData.summary}></textarea>
            <input class="btn submit" type="submit" value="Edit Game">

        </div>
    </form>
</section>
`;