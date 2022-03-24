function validateInputs(data) {
    if (Object.values(data).some(x => !x)) {
        throw new Error('Please, fill all the fields!');
    }
}

function validatePasswords(password, repeatPassword) {
    if (password !== repeatPassword) {
        throw new Error('Passwords should match!');
    }
}

function validateMake(make) {
    return make.length >= 4;
}

function validateModel(model) {
    return model.length >= 4;
}

function validateYear(year) {
    const value = Number(year);

    return (value >= 1950 && value <= 2050);
}

function validateDescription(description) {
    return description.length > 10;
}

function validatePrice(price) {
    const value = Number.isNaN(price);

    return (!value && Number(price) > 0);
}

function validateImage(img) {
    return img.trim() ? true : false;
}

function validateFurnitureData(checker, furnitureData) {
    checker.make = validateMake(furnitureData.make);
    checker.model = validateModel(furnitureData.model);
    checker.year = validateYear(furnitureData.year);
    checker.description = validateDescription(furnitureData.description);
    checker.price = validatePrice(furnitureData.price);
    checker.img = validateImage(furnitureData.img);
}

export default {
    validateInputs,
    validatePasswords,
    validateFurnitureData,
}