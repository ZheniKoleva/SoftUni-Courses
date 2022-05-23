const {assert, expect} = require('chai');
const lookupChar = require('../03. Char Lookup');

describe('Char Lookup Tests', () => {
    it('should return undefined for wrong input data types', () => {
        expect(lookupChar(undefined, 0)).to.be.undefined;
        expect(lookupChar([], 0)).to.be.undefined;
        expect(lookupChar(true, 0)).to.be.undefined;
        expect(lookupChar({}, 0)).to.be.undefined;
        expect(lookupChar('test', 3.5)).to.be.undefined;
        expect(lookupChar('test', NaN)).to.be.undefined;
    })

    it('should return message for incorrect index', () => {
        expect(lookupChar('test', -1)).to.be.equal('Incorrect index');
        expect(lookupChar('test', 5)).to.be.equal('Incorrect index');
    })

    it('should return correct symbol', () => {
        expect(lookupChar('test', 0)).to.be.equal('t');
        expect(lookupChar('test', 2)).to.be.equal('s');
    })
})