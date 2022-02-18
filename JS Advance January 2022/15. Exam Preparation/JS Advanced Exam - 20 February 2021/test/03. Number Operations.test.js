const { assert, expected } = require("chai");
const numberOperations = require("../03. Number Operations")

describe('NumberOperations Tests', function() {
    describe('powNumber tests', function() {
        it('should return number multiplied by itself', function() {
            assert.equal(numberOperations.powNumber(2), 4);
            assert.equal(numberOperations.powNumber(12), 144);
        });
     });


     describe('numberChecker tests', function() {
        it('should throw error if the number isNaN', function() {

            assert.throws(() => numberOperations.numberChecker('123abc'), Error, 'The input is not a number!');            
            assert.throws(() => numberOperations.numberChecker({}), Error, 'The input is not a number!');
            assert.throws(() => numberOperations.numberChecker(undefined), Error, 'The input is not a number!');
            assert.throws(() => numberOperations.numberChecker(NaN), Error, 'The input is not a number!');           
            assert.throws(() => numberOperations.numberChecker(function(){}), Error, 'The input is not a number!');           
        });

        it('should return appropriate message if number is lower than 100', function() {

            assert.equal(numberOperations.numberChecker(0), 'The number is lower than 100!');          
            assert.equal(numberOperations.numberChecker(-1), 'The number is lower than 100!');          
            assert.equal(numberOperations.numberChecker(99.99), 'The number is lower than 100!');
        });

        it('should return appropriate message if number is higher than 100 or equal', function() {

            assert.equal(numberOperations.numberChecker(100), 'The number is greater or equal to 100!');          
            assert.equal(numberOperations.numberChecker(1234.4321), 'The number is greater or equal to 100!');          
            assert.equal(numberOperations.numberChecker(9999), 'The number is greater or equal to 100!');
        });
     });

     describe('sumArray tests', function() {
        it('should return correct array when arra1 length > arra2 length', function() {
            const array1 = [1, 2, 3, 4];
            const array2 = [5, 6, 7];

            const expected = [6, 8, 10, 4];
            const actual = numberOperations.sumArrays(array1, array2);
            assert.deepEqual(actual, expected);
        });

        it('should return correct array when arra1 length < arra2 length', function() {
            const array1 = [1, 2];
            const array2 = [5, 6, 7, 8, 9];

            const expected = [6, 8, 7, 8, 9];
            const actual = numberOperations.sumArrays(array1, array2);
            assert.deepEqual(actual, expected);
        }); 
        
        it('should return correct array when one array is empty', function() {
            const array1 = [];
            const array2 = [5, 6, 7, 8, 9];

            const expected = [5, 6, 7, 8, 9];
            const actual = numberOperations.sumArrays(array1, array2);
            assert.deepEqual(actual, expected);
        }); 
     });
     
});
