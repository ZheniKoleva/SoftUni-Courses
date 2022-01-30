const { assert, expect } = require('chai');
const rgbToHexColor = require('../06. RGB to Hex');

describe('RGB to Hex', () => {
    it('should return white: #FFFFFF', () => {
        //expect(rgbToHexColor(255, 255, 255)).to.be.equal('#FFFFFF');
        assert.equal(rgbToHexColor(255, 255, 255), '#FFFFFF');
    })

    it('should return black: #000000', () => {
        //expect(rgbToHexColor(0, 0, 0)).to.be.equal('#000000');
        assert.equal(rgbToHexColor(0, 0, 0), '#000000');
    })

    it('should return silver: #C0C0C0', () => {
        //expect(rgbToHexColor(192, 192, 192)).to.be.equal('#C0C0C0');
        assert.equal(rgbToHexColor(192, 192, 192), '#C0C0C0');
    })

    it('should return undefined for invalid red', () => {
        assert.isUndefined(rgbToHexColor('test', 0, 0));
        assert.isUndefined(rgbToHexColor(-1, 0, 0));
        assert.isUndefined(rgbToHexColor(256, 0, 0));
    })

    it('should return undefined for invalid green', () => {
        assert.isUndefined(rgbToHexColor(0, 'test', 0));
        assert.isUndefined(rgbToHexColor(0, -1, 0));
        assert.isUndefined(rgbToHexColor(0, 256, 0));
    })

    it('should return undefined for invalid blue', () => {
        assert.isUndefined(rgbToHexColor(0, 0, 'test'));
        assert.isUndefined(rgbToHexColor(0, 0, -1));
        assert.isUndefined(rgbToHexColor(0, 0, 256));
    })

})