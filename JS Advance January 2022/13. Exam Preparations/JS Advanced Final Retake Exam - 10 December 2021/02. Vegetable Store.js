class VegetableStore {
    constructor(owner, location) {
        this.owner = owner;
        this.location = location;
        this.availableProducts = [];
        this._addedProducts = [];        
    }

    loadingVegetables(vegetables) {

        vegetables.forEach(x => {
            let [type, quantity, price] = x.split(' '); 
            quantity = Number(quantity);           
            price = Number(price);           

            const searchedProduct = this._findProduct(type);

            if(!searchedProduct) {
                const product = {
                    type,
                    quantity,
                    price,
                }

                this.availableProducts.push(product);
                this._addedProducts.push(type);

            }else {
                searchedProduct.quantity += quantity;

                if (searchedProduct.price <= price) {
                    searchedProduct.price = price;
                }
            }            
        });

        return `Successfully added ${this._addedProducts.join(', ')}`;
    }

    buyingVegetables(selectedProducts) {
        let totalPrice = 0.00;

        selectedProducts.forEach(x => {
            let [type, quantity] = x.split(' ');
            quantity = Number(quantity);

            const searchedProduct = this._findProduct(type);           

            if (!searchedProduct) {               
                const message = `${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`;

                throw new Error(message);
            }

            if (searchedProduct.quantity < quantity) {                
                const message = `The quantity ${quantity} for the vegetable ${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`;

                throw new Error(message);
            }

            totalPrice += searchedProduct.price * quantity;
            searchedProduct.quantity -= quantity;
        });

        return `Great choice! You must pay the following amount $${totalPrice.toFixed(2)}.`
    }

    rottingVegetable(type, quantity) {
        const searchedProduct = this._findProduct(type);

        if (!searchedProduct) {
            throw new Error(`${type} is not available in the store.`);
        }

        if (searchedProduct.quantity < Number(quantity)) {
            searchedProduct.quantity = 0;

            return `The entire quantity of the ${type} has been removed.`;
        }

        searchedProduct.quantity -= Number(quantity);

        return `Some quantity of the ${type} has been removed.`;
    }

    revision() {
        const firstRow = 'Available vegetables:';

        const orderedProducts = this.availableProducts
            .sort((a, b) => a.price - b.price)
            .map(x => `${x.type}-${x.quantity}-$${x.price}`)
            .join('\n');

        const lastRow = `The owner of the store is ${this.owner}, and the location is ${this.location}.`

        return `${firstRow}\n${orderedProducts}\n${lastRow}`;
    }

    _findProduct(type) {
        return this.availableProducts.find(x => x.type == type);
    }

}

// Input 1
let vegStore = new VegetableStore("Jerrie Munro", "1463 Pette Kyosheta, Sofia");
console.log(vegStore.loadingVegetables(["Okra 2.5 3.5", "Beans 10 2.8", "Celery 5.5 2.2", "Celery 0.5 2.5"]));

// // Input 2
let vegStore = new VegetableStore("Jerrie Munro", "1463 Pette Kyosheta, Sofia");
console.log(vegStore.loadingVegetables(["Okra 2.5 3.5", "Beans 10 2.8", "Celery 5.5 2.2", "Celery 0.5 2.5"]));
console.log(vegStore.buyingVegetables(["Okra 1"]));
console.log(vegStore.buyingVegetables(["Beans 8", "Okra 1.5"]));
console.log(vegStore.buyingVegetables(["Banana 1", "Beans 2"]));

// // Input 3
let vegStore = new VegetableStore("Jerrie Munro", "1463 Pette Kyosheta, Sofia");
console.log(vegStore.loadingVegetables(["Okra 2.5 3.5", "Beans 10 2.8", "Celery 5.5 2.2", "Celery 0.5 2.5"]));
console.log(vegStore.rottingVegetable("Okra", 1));
console.log(vegStore.rottingVegetable("Okra", 2.5));
console.log(vegStore.buyingVegetables(["Beans 8", "Okra 1.5"]));

// // Input 4
let vegStore = new VegetableStore("Jerrie Munro", "1463 Pette Kyosheta, Sofia");
console.log(vegStore.loadingVegetables(["Okra 2.5 3.5", "Beans 10 2.8", "Celery 5.5 2.2", "Celery 0.5 2.5"]));
console.log(vegStore.rottingVegetable("Okra", 1));
console.log(vegStore.rottingVegetable("Okra", 2.5));
console.log(vegStore.buyingVegetables(["Beans 8", "Celery 1.5"]));
console.log(vegStore.revision());



