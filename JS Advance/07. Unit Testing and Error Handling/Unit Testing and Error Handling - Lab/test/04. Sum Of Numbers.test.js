const { expect } = require('chai');
const sum = require('../04. Sum Of Numbers');

describe('Sum Of Numbers Tests', () => {
    it('check if sum positive numbers', () => {
        expect(sum([1, 2, 3])).to.equal(6);
    })

    it('check if sum negative numbers', () => {
        expect(sum([-1, -2, -3])).to.equal(-6);        
    })

    it('return 0 if input is an empty array', () => {
        expect(sum([])).to.equal(0);
    })
})