const { expect, assert } = require('chai');
const createCalculator = require('../07. Add and Subtract');

describe('Add and Subtract tests', () => {  
    it('check if return object', () => {
        assert.isObject(createCalculator());       
    })

    it('should return object with correct properties', () => {
        assert.property(createCalculator(), 'add');
        assert.property(createCalculator(), 'subtract');
        assert.property(createCalculator(), 'get');
    })

    it('should return sum = 0', () => {
        const calculator = createCalculator();
        assert.equal(calculator.get(), 0);
    })

    it('check add function', () => {
        const calculator = createCalculator();
        calculator.add(1);
        calculator.add('1');        
        assert.equal(calculator.get(), 2);
    })
    
    it('check subtract function', () => {
        const calculator = createCalculator();
        calculator.subtract(1);
        calculator.subtract('2');        
        assert.equal(calculator.get(), -3);
    })

    it('check add and subtract function', () => {
        const calculator = createCalculator();
        calculator.add(5);
        calculator.subtract(7); 
        assert.equal(calculator.get(), -2);
        calculator.add(5);        
        assert.equal(calculator.get(), 3);
    })
})