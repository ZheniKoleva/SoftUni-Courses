const { assert, expect } = require('chai');
const library = require('../03. Library/library');

describe("Library tests", function () {
    describe("calcPriceOfBook tests", function () {
        it("should throws error if book parameter is not a string", function () {
            assert.throws(() => library.calcPriceOfBook(123, 2022), Error, 'Invalid input');
            assert.throws(() => library.calcPriceOfBook([], 2022), Error, 'Invalid input');
            assert.throws(() => library.calcPriceOfBook({}, 2022), Error, 'Invalid input');
            assert.throws(() => library.calcPriceOfBook(true, 2022), Error, 'Invalid input');
            assert.throws(() => library.calcPriceOfBook(123.45, 2022), Error, 'Invalid input');
        });

        it("should throws error if year parameter is not an integer number", function () {
            assert.throws(() => library.calcPriceOfBook('Test book', []), Error, 'Invalid input');
            assert.throws(() => library.calcPriceOfBook('Test book', {}), Error, 'Invalid input');
            assert.throws(() => library.calcPriceOfBook('Test book', true), Error, 'Invalid input');
            assert.throws(() => library.calcPriceOfBook('Test book', 123.45), Error, 'Invalid input');
        });

        it("should return default price (20) if year is above 1980", function () {
            const bookName = 'Test book';          

            const expected = `Price of Test book is 20.00`;
            const actual = library.calcPriceOfBook(bookName, 1981);
            assert.equal(actual, expected);

            const actual2 = library.calcPriceOfBook(bookName, 2022);
            assert.equal(actual2, expected);
        });

        it("should return default price (20) with 50 % discount if year is equal to/less than 1980", function () {
            const bookName = 'Test book';            
            const expected = `Price of Test book is 10.00`;

            const actual = library.calcPriceOfBook(bookName, 1980);
            assert.equal(actual, expected);

            const actual2 = library.calcPriceOfBook(bookName, 1970);
            assert.equal(actual2, expected);
        });
    });

    describe("findBook tests", function () {
        it("should throws error if book array is empty", function () {
            assert.throws(() => library.findBook([], 'Test book'), Error, 'No books currently available');           
        });

        it("should return correct message if desired book is not available", function () {
            const booksArray = ["Troy", "Life Style", "Torronto"];
            const desiredBook = 'Test book';

            const expected = 'The book you are looking for is not here!';            
            const actual = library.findBook(booksArray, desiredBook);
            assert.equal(actual, expected);
        });

        it("should return correct message if desired book is available", function () {
            const booksArray = ["Troy", "Life Style", "Torronto"];
            const desiredBook = 'Life Style';

            const expected = 'We found the book you want.';            
            const actual = library.findBook(booksArray, desiredBook);
            assert.equal(actual, expected);
        });
    });

    describe("arrangeTheBooks tests", function () {
        it("should throws error if books count is less than 0 or is not an integer number", function () {
            assert.throws(() => library.arrangeTheBooks(-1), Error, 'Invalid input');           
            assert.throws(() => library.arrangeTheBooks(true), Error, 'Invalid input');           
            assert.throws(() => library.arrangeTheBooks('test'), Error, 'Invalid input');           
            assert.throws(() => library.arrangeTheBooks([]), Error, 'Invalid input');           
            assert.throws(() => library.arrangeTheBooks({}), Error, 'Invalid input');           
            assert.throws(() => library.arrangeTheBooks(123.45), Error, 'Invalid input');           
        });

        it("should return correct message if all the books are arranged (books count <= 40)", function () {           
            const expected = 'Great job, the books are arranged.'; 

            const actual = library.arrangeTheBooks(40);
            assert.equal(actual, expected);

            const actual2 = library.arrangeTheBooks(1);
            assert.equal(actual2, expected);

            const actual3 = library.arrangeTheBooks(1);
            assert.equal(actual3, expected);
        });

         it("should return correct message if there is no available space (40) to arrange the books)", function () {           
            const expected = 'Insufficient space, more shelves need to be purchased.'; 

            const actual = library.arrangeTheBooks(41);
            assert.equal(actual, expected);

            const actual2 = library.arrangeTheBooks(100);
            assert.equal(actual2, expected);            
        });
    });
     
});
