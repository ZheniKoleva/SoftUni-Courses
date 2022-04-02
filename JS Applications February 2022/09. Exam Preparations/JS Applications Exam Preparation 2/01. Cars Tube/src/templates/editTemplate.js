import { html } from './../../node_modules/lit-html/lit-html.js';

export const editTemplate = (carData, submitHandler) => html`
<section id="edit-listing">
    <div class="container">

        <form id="edit-form" @submit=${submitHandler}>
            <h1>Edit Car Listing</h1>
            <p>Please fill in this form to edit an listing.</p>
            <hr>

            <p>Car Brand</p>
            <input type="text" placeholder="Enter Car Brand" name="brand" .value=${carData.brand}>

            <p>Car Model</p>
            <input type="text" placeholder="Enter Car Model" name="model" .value=${carData.model}>

            <p>Description</p>
            <input type="text" placeholder="Enter Description" name="description" .value=${carData.description}>

            <p>Car Year</p>
            <input type="number" placeholder="Enter Car Year" name="year" .value=${Number(carData.year)}>

            <p>Car Image</p>
            <input type="text" placeholder="Enter Car Image" name="imageUrl" .value=${carData.imageUrl}>

            <p>Car Price</p>
            <input type="number" placeholder="Enter Car Price" name="price" .value=${Number(carData.price)}>

            <hr>
            <input type="submit" class="registerbtn" value="Edit Listing">
        </form>
    </div>
</section>
`;