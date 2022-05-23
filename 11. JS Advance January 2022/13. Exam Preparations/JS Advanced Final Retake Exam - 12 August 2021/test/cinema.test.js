const { assert, expect } = require('chai');
const cinema = require('../03. Cinema/cinema');

describe("Cinema Tests", function () {
    describe("showMovies tests", function () {
        it("should return movies joined by comma and space", function () {
            const movies = ['King Kong', 'The Tomorrow War', 'Joker'];

            const expected = 'King Kong, The Tomorrow War, Joker';
            const actual = cinema.showMovies(movies);

            assert.deepEqual(actual, expected);
        });

        it("should return correct message if input array is empty", function () {
            const expected = 'There are currently no movies to show.';
            const actual = cinema.showMovies([]);

            assert.equal(actual, expected);
        });
    });

    describe("ticketPrice tests", function () {
        it("should throws error if projectType is unexisting", function () { 
            assert.throws(() => cinema.ticketPrice('kids'), Error, 'Invalid projection type.');
        });

        it("should return correct price", function () {
            const  possiblePrices = {
                "Premiere": 12.00,
                "Normal": 7.50,
                "Discount": 5.50
            };

            assert.equal(cinema.ticketPrice('Premiere'), possiblePrices['Premiere']);
            assert.equal(cinema.ticketPrice('Normal'), possiblePrices['Normal']);
            assert.equal(cinema.ticketPrice('Discount'), possiblePrices['Discount']);
        });
    });

    describe("swapSeatsInHall tests", function () {
        it("should throws error if first seat number is not in correct type or is greater than hall capacity (20), equal/less than 0, or equal to second", function () { 
            const expected = 'Unsuccessful change of seats in the hall.';

            assert.equal(cinema.swapSeatsInHall('123', 1), expected);
            assert.equal(cinema.swapSeatsInHall(1.23, 1), expected);
            assert.equal(cinema.swapSeatsInHall(0, 1), expected);
            assert.equal(cinema.swapSeatsInHall(-1, 1), expected);
            assert.equal(cinema.swapSeatsInHall(21, 1), expected);
            assert.equal(cinema.swapSeatsInHall(1, 1), expected);            
        });

        it("should throws error if second seat number is not in correct type or is greater than hall capacity (20), equal/less than 0, or equal to first", function () { 
            const expected = 'Unsuccessful change of seats in the hall.';

            assert.equal(cinema.swapSeatsInHall(1, '123'), expected);
            assert.equal(cinema.swapSeatsInHall(1, 1.23), expected);
            assert.equal(cinema.swapSeatsInHall(1, 0), expected);
            assert.equal(cinema.swapSeatsInHall(1, -1), expected);
            assert.equal(cinema.swapSeatsInHall(1, 21), expected);
            assert.equal(cinema.swapSeatsInHall(1, 1), expected);            
        });

        it("should return correct message if the two seats are valid", function () { 
            const expected = 'Successful change of seats in the hall.';
            const actual = cinema.swapSeatsInHall(13, 19);
            const actual2 = cinema.swapSeatsInHall(1, 20);

            assert.equal(actual, expected);                    
            assert.equal(actual2, expected);                    
        });

    });

});
