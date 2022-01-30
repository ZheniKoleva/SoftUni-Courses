const {assert, expect} = require('chai');
const isSymmetric = require('../05. Check for Symmetry');

describe('Check for Symmetry', () => {
    it('should return false if input is not an array', () => {
        expect(isSymmetric(1)).to.be.false;
        expect(isSymmetric('alabala')).to.be.false;
        expect(isSymmetric({})).to.be.false;
    })

    it('should return true for symmetric array with numbers', () => {
        expect(isSymmetric([1, 2, 2, 1])).to.be.true;
        expect(isSymmetric([1, 2, 3, 4, 3, 2, 1])).to.be.true;
    })

    it('should return true for symmetric array with strings', () => {
        expect(isSymmetric(['a', 'b', 'c', 'b', 'a'])).to.be.true;
        expect(isSymmetric(['a', 'a'])).to.be.true;
    })

    it('should return false for asymmetric array with numbers', () => {
        expect(isSymmetric([1, 2, 2])).to.be.false;
        expect(isSymmetric([1, 2, 3])).to.be.false;
    })

    it('should return false for asymmetric array with strings', () => {
        expect(isSymmetric(['a', 'b'])).to.be.false;
        expect(isSymmetric(['a', 'b', 'c'])).to.be.false;
    })

    it('should return false for an array with strings and numbers', () => {
        expect(isSymmetric([1, 2, 3, '2', '1'])).to.be.false;        
    })
})