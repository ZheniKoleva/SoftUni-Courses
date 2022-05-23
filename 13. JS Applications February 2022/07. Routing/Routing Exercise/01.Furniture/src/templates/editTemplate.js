import { html } from './../../node_modules/lit-html/lit-html.js';

export const editTemplate = (formInfo) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Edit Furniture</h1>
        <p>Please fill all fields.</p>
    </div>
</div>
<form @submit=${formInfo.update}>
    <div class="row space-top">
        <div class="col-md-4">
            <div class="form-group">
                <label class="form-control-label" for="new-make">Make</label>
                <input class="form-control ${formInfo.checker.make ? 'is-valid' : 'is-invalid'}" id="new-make" type="text" name="make" .value=${formInfo.furniture.make}>
            </div>
            <div class="form-group has-success">
                <label class="form-control-label" for="new-model">Model</label>
                <input class="form-control ${formInfo.checker.model ? 'is-valid' : 'is-invalid'}" id="new-model" type="text" name="model" .value=${formInfo.furniture.model}>
            </div>
            <div class="form-group has-danger">
                <label class="form-control-label" for="new-year">Year</label>
                <input class="form-control ${formInfo.checker.year ? 'is-valid' : 'is-invalid'}" id="new-year" type="number" name="year" .value=${formInfo.furniture.year}>
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-description">Description</label>
                <input class="form-control ${formInfo.checker.description ? 'is-valid' : 'is-invalid'}" id="new-description" type="text" name="description" .value=${formInfo.furniture.description}>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="form-control-label" for="new-price">Price</label>
                <input class="form-control ${formInfo.checker.price ? 'is-valid' : 'is-invalid'}" id="new-price" type="number" name="price" .value=${formInfo.furniture.price}>
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-image">Image</label>
                <input class="form-control ${formInfo.checker.img ? 'is-valid' : 'is-invalid'}" id="new-image" type="text" name="img" .value=${formInfo.furniture.img}>
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-material">Material (optional)</label>
                <input class="form-control" id="new-material" type="text" name="material" .value=${formInfo.furniture.material}>
            </div>
            <input type="submit" class="btn btn-info" value="Edit" />
        </div>
    </div>
</form>
`;