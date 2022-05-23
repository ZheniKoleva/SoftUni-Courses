const {assert, expect} = require('chai');
const mathEnforcer = require('../04. Math Enforcer');

describe('mathEnforcer', () =>{
    describe('addFive tests', () => {
        it('should return undefined if input parameter is not a number', () =>{
            assert.isUndefined(mathEnforcer.addFive(undefined));
            assert.isUndefined(mathEnforcer.addFive('test'));
            assert.isUndefined(mathEnforcer.addFive(false));
            assert.isUndefined(mathEnforcer.addFive({}));
            assert.isUndefined(mathEnforcer.addFive(['stupid', 'tests']));
        })

        it('should add 5 to positive input number', () =>{
            assert.equal(mathEnforcer.addFive(0), 5);
            assert.equal(mathEnforcer.addFive(2), 7);                     
        })
        
        it('should add 5 to negative input number', () =>{            
            assert.equal(mathEnforcer.addFive(-5), 0);
            assert.equal(mathEnforcer.addFive(-2), 3); 
            assert.equal(mathEnforcer.addFive(-15), -10); 
        })

        it('should add 5 to floating positive/negative input number', () =>{            
            assert.closeTo(mathEnforcer.addFive(-5.67), -0.67, 0.01);
            assert.closeTo(mathEnforcer.addFive(3.14), 8.14, 0.01);
            assert.closeTo(mathEnforcer.addFive(-3.00), 2.00, 0.01);           
        })
    })

    describe('subtractTen tests', () => {
        it('should return undefined if input parameter is not a number', () =>{
            assert.isUndefined(mathEnforcer.subtractTen(undefined));
            assert.isUndefined(mathEnforcer.subtractTen('test'));
            assert.isUndefined(mathEnforcer.subtractTen(false));
            assert.isUndefined(mathEnforcer.subtractTen({}));
            assert.isUndefined(mathEnforcer.subtractTen(['stupid', 'tests']));
        })

        it('should subtract 10 from positive input number', () =>{
            assert.equal(mathEnforcer.subtractTen(0), -10);
            assert.equal(mathEnforcer.subtractTen(2), -8);                     
            assert.equal(mathEnforcer.subtractTen(23), 13);                     
        })
        
        it('should subtract 10 from negative input number', () =>{            
            assert.equal(mathEnforcer.subtractTen(-5), -15);
            assert.equal(mathEnforcer.subtractTen(7), -3); 
            assert.equal(mathEnforcer.subtractTen(9), -1); 
            assert.equal(mathEnforcer.subtractTen(27), 17); 
        })

        it('should subtract 10 from floating positive/negative input number', () =>{            
            assert.closeTo(mathEnforcer.subtractTen(-5.67), -15.67, 0.01);
            assert.closeTo(mathEnforcer.subtractTen(3.14), -6.86, 0.01);
            assert.closeTo(mathEnforcer.subtractTen(12.345), 2.345, 0.01);           
        })
    })

    describe('sum tests', () => {
        it('should return undefined if input parameters are not a number', () =>{
            assert.isUndefined(mathEnforcer.sum(undefined, 5));
            assert.isUndefined(mathEnforcer.sum('test', 5));
            assert.isUndefined(mathEnforcer.sum(false, 5));
            assert.isUndefined(mathEnforcer.sum({}, 5));
            assert.isUndefined(mathEnforcer.sum(['stupid', 'tests'], 5));

            assert.isUndefined(mathEnforcer.sum(5, undefined));
            assert.isUndefined(mathEnforcer.sum(5, 'test'));
            assert.isUndefined(mathEnforcer.sum(5, false));
            assert.isUndefined(mathEnforcer.sum(5, {}));
            assert.isUndefined(mathEnforcer.sum(5, ['stupid', 'tests']));
        })

        it('should return the sum of two positive input numbers', () =>{
            assert.equal(mathEnforcer.sum(0, 5), 5);
            assert.equal(mathEnforcer.sum(23, 17), 40); 
        })
        
        it('should return the sum of two negative input number', () =>{            
            assert.equal(mathEnforcer.sum(-5, -7), -12);
            assert.equal(mathEnforcer.sum(-45, 13), -32); 
            assert.equal(mathEnforcer.sum(2, -1), 1); 
            assert.equal(mathEnforcer.sum(3, -5), -2); 
        })

        it('should subtract 10 from floating positive/negative input number', () =>{            
            assert.closeTo(mathEnforcer.sum(5.20, 3.80), 9.00, 0.01);
            assert.closeTo(mathEnforcer.sum(3.14, -2.14), 1.00, 0.01);
            assert.closeTo(mathEnforcer.sum(-1.30, -2.70), -4.00, 0.01);           
        })
    })
})