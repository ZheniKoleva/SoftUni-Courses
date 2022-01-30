const { expect, assert } = require('chai');
const isOddOrEven = require('../02. Even Or Odd');

describe('Even or Odd tests', () => {
    it('should return undefined for different input type', () =>{
        assert.isUndefined(isOddOrEven(5));
        assert.isUndefined(isOddOrEven(['test']));
        assert.isUndefined(isOddOrEven({}));
        assert.isUndefined(isOddOrEven(undefined));
    })

    it('should return even for string with even length', () =>{
        assert.equal(isOddOrEven('hi'), 'even');
        assert.equal(isOddOrEven('test'), 'even');        
                
    })

    it('should return odd for string with odd length', () =>{
        assert.equal(isOddOrEven('hello'), 'odd');
        assert.equal(isOddOrEven('stupid test'), 'odd');        
    })

    it('should works correctly with multiple different strings', () =>{
        assert.equal(isOddOrEven('alabala'), 'odd');
        assert.equal(isOddOrEven('nica'), 'even');        
    })
})