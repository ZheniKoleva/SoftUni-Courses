const { assert, expected } = require('chai');
const flowerShop = require('../03. Flowers Shop/flowerShop');

describe("flowerShop tests", () => {
    describe("calcPriceOfFlowers tests", () => {
        it("should throw error if flower parameter is not a string", () => {
            assert.throws(() => flowerShop.calcPriceOfFlowers(123, 10, 1), Error, 'Invalid input!');
            assert.throws(() => flowerShop.calcPriceOfFlowers(true, 10, 1), Error, 'Invalid input!');
            assert.throws(() => flowerShop.calcPriceOfFlowers(123.45, 10, 1), Error, 'Invalid input!');
            assert.throws(() => flowerShop.calcPriceOfFlowers([], 10, 1), Error, 'Invalid input!');
            assert.throws(() => flowerShop.calcPriceOfFlowers({}, 10, 1), Error, 'Invalid input!');
            assert.throws(() => flowerShop.calcPriceOfFlowers(NaN, 10, 1), Error, 'Invalid input!');
            assert.throws(() => flowerShop.calcPriceOfFlowers(undefined, 10, 1), Error, 'Invalid input!');
        });

        it("should throw error if price parameter is not an integer number", () => {
            assert.throws(() => flowerShop.calcPriceOfFlowers('rose', 10.123, 1), Error, 'Invalid input!');
            assert.throws(() => flowerShop.calcPriceOfFlowers('rose', true, 1), Error, 'Invalid input!');
            assert.throws(() => flowerShop.calcPriceOfFlowers('rose', [], 1), Error, 'Invalid input!');
            assert.throws(() => flowerShop.calcPriceOfFlowers('rose', {}, 1), Error, 'Invalid input!');
            assert.throws(() => flowerShop.calcPriceOfFlowers('rose', NaN, 1), Error, 'Invalid input!');
            assert.throws(() => flowerShop.calcPriceOfFlowers('rose', '1', 1), Error, 'Invalid input!');
            assert.throws(() => flowerShop.calcPriceOfFlowers('rose', undefined, 1), Error, 'Invalid input!');

        });

        it("should throw error if quantity parameter is not an integer number", () => {
            assert.throws(() => flowerShop.calcPriceOfFlowers('rose', 1, 10.123), Error, 'Invalid input!');
            assert.throws(() => flowerShop.calcPriceOfFlowers('rose', 1, true), Error, 'Invalid input!');
            assert.throws(() => flowerShop.calcPriceOfFlowers('rose', 1, []), Error, 'Invalid input!');
            assert.throws(() => flowerShop.calcPriceOfFlowers('rose', 1, {}), Error, 'Invalid input!');
            assert.throws(() => flowerShop.calcPriceOfFlowers('rose', 1, NaN), Error, 'Invalid input!');
            assert.throws(() => flowerShop.calcPriceOfFlowers('rose', 1, '1'), Error, 'Invalid input!');
            assert.throws(() => flowerShop.calcPriceOfFlowers('rose', 1, undefined), Error, 'Invalid input!');

        });

        it("should return quantity parameter multiplued by price parameter fixed to second digit", () => {
            const actual = flowerShop.calcPriceOfFlowers('rose', 1, 10);
            const expected = `You need $10.00 to buy rose!`;

            assert.equal(actual, expected);
        });
    });

    describe("checkFlowersAvailable tests", () => {
        it("should return correct message if flower exist", () => {
            const gardenArr = ["Rose", "Lily", "Orchid"];

            const actual = flowerShop.checkFlowersAvailable('Rose', gardenArr);
            const expected = 'The Rose are available!';
            assert.equal(actual, expected);

            const actual2 = flowerShop.checkFlowersAvailable('Lily', gardenArr);
            const expected2 = 'The Lily are available!';
            assert.equal(actual2, expected2);
        });

        it("should return correct message if flower do not exist", () => {
            const gardenArr = ["Rose", "Lily", "Orchid"];

            const actual = flowerShop.checkFlowersAvailable('Palm', gardenArr);
            const expected = 'The Palm are sold! You need to purchase more!';
            assert.equal(actual, expected);           
        });     
        
    });

    describe("sellFlowers tests", () => {
        it("should throw error if array parameter is not an array", () => {
            assert.throws(() => flowerShop.sellFlowers(123, 0), Error, 'Invalid input!');
            assert.throws(() => flowerShop.sellFlowers(true, 0), Error, 'Invalid input!');
            assert.throws(() => flowerShop.sellFlowers(123.45, 0), Error, 'Invalid input!');
            assert.throws(() => flowerShop.sellFlowers('test', 0), Error, 'Invalid input!');
            assert.throws(() => flowerShop.sellFlowers({}, 0), Error, 'Invalid input!');
            assert.throws(() => flowerShop.sellFlowers(NaN, 0), Error, 'Invalid input!');
            assert.throws(() => flowerShop.sellFlowers(undefined, 0), Error, 'Invalid input!');
        });

        it("should throw error if space parameter is not an integer number or it is outside of array parameter length", () => {
            const gardenArr = ["Rose", "Lily", "Orchid"];           
            
            assert.throws(() => flowerShop.sellFlowers(gardenArr, true), Error, 'Invalid input!');
            assert.throws(() => flowerShop.sellFlowers(gardenArr, 123.45), Error, 'Invalid input!');
            assert.throws(() => flowerShop.sellFlowers(gardenArr, 'test'), Error, 'Invalid input!');
            assert.throws(() => flowerShop.sellFlowers(gardenArr, {}), Error, 'Invalid input!');
            assert.throws(() => flowerShop.sellFlowers(gardenArr, NaN), Error, 'Invalid input!');
            assert.throws(() => flowerShop.sellFlowers(gardenArr, undefined), Error, 'Invalid input!');
            assert.throws(() => flowerShop.sellFlowers(gardenArr, []), Error, 'Invalid input!');

            assert.throws(() => flowerShop.sellFlowers(gardenArr, -1), Error, 'Invalid input!');
            assert.throws(() => flowerShop.sellFlowers(gardenArr, -10), Error, 'Invalid input!');
            assert.throws(() => flowerShop.sellFlowers(gardenArr, 3), Error, 'Invalid input!');
            assert.throws(() => flowerShop.sellFlowers(gardenArr, 10), Error, 'Invalid input!');            
        });  
        
        it("should return flowers without the flower on space parameter", () => {
            const gardenArr = ["Rose", "Lily", "Orchid"];

            const actual = flowerShop.sellFlowers(gardenArr, 1);
            const expected = 'Rose / Orchid';
            assert.equal(actual, expected);           
        });        
        
    });
});
