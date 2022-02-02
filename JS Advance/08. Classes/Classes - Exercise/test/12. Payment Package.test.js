const { assert, expect } = require('chai');
const PaymentPackage = require('../12. Payment Package');

describe('Payment Package Class Tests',() => {
    describe('name property tests', () =>{
        it('should throw error for incorrect data type for name', () => {
            assert.throws(() => new PaymentPackage(1, 1), 'Name must be a non-empty string');
            assert.throws(() => new PaymentPackage([], 1), 'Name must be a non-empty string');
            assert.throws(() => new PaymentPackage(true, 1), 'Name must be a non-empty string');
            assert.throws(() => new PaymentPackage({}, 1), 'Name must be a non-empty string');
            assert.throws(() => new PaymentPackage(1.23, 1), 'Name must be a non-empty string');            
            assert.throws(() => new PaymentPackage(null, 1), 'Name must be a non-empty string');            
            assert.throws(() => new PaymentPackage(undefined, 1), 'Name must be a non-empty string');            
        })

        it('should throw error for name with length 0', () => {
            assert.throws(() => new PaymentPackage('', 1), 'Name must be a non-empty string');            
        })

        it('should set name properly', () => {
            const payment = new PaymentPackage('Economic', 100);
            assert.equal(payment.name, 'Economic'); 
            
            payment.name = 'Engeneering';
            assert.equal(payment.name, 'Engeneering'); 
        })
    })

    describe('value property tests', () =>{
        it('should throw error for incorrect data type for value', () => {
            assert.throws(() => new PaymentPackage('Economic', true), 'Value must be a non-negative number');
            assert.throws(() => new PaymentPackage('Economic', '1'), 'Value must be a non-negative number');
            assert.throws(() => new PaymentPackage('Economic', {}), 'Value must be a non-negative number');
            assert.throws(() => new PaymentPackage('Economic', []), 'Value must be a non-negative number');                    
            assert.throws(() => new PaymentPackage('Economic', null), 'Value must be a non-negative number');                    
            assert.throws(() => new PaymentPackage('Economic', undefined), 'Value must be a non-negative number');                    
        })

        it('should throw error for negative value', () => {
            assert.throws(() => new PaymentPackage('Economic', -1.23), 'Value must be a non-negative number');            
        })

        it('should set value properly', () => {
            const payment = new PaymentPackage('Economic', 100);
            assert.equal(payment.value, 100); 
            
            const payment2 = new PaymentPackage('Economic', 123.45);
            assert.closeTo(payment2.value, 123.45, 0.01);

            payment2.value = 23;
            assert.equal(payment2.value, 23); 
        })
    })

    describe('VAT property tests', () => {
        it('should throw error for incorrect data type for value', () => {
            const payment = new PaymentPackage('Economic', 100);

            assert.throws(() => payment.VAT = null, 'VAT must be a non-negative number');
            assert.throws(() => payment.VAT = undefined, 'VAT must be a non-negative number');
            assert.throws(() => payment.VAT = [], 'VAT must be a non-negative number');
            assert.throws(() => payment.VAT = {}, 'VAT must be a non-negative number');                    
            assert.throws(() => payment.VAT = 'test', 'VAT must be a non-negative number');                    
            assert.throws(() => payment.VAT = true, 'VAT must be a non-negative number');                    
        })

        it('should throw error for negative value', () => {
            const payment = new PaymentPackage('Economic', 100);

            assert.throws(() => payment.VAT = -1.23, 'VAT must be a non-negative number');            
        })

        it('should set VAT with default value 20', () => {
            const payment = new PaymentPackage('Economic', 100);

            assert.equal(payment.VAT, 20);         
        })

        it('should set VAT with new input value', () => {
            const payment = new PaymentPackage('Economic', 100);
            payment.VAT = 10;            
            assert.equal(payment.VAT, 10); 
            
            payment.VAT = 123.45; 
            assert.closeTo(payment.VAT, 123.45, 0.01);         
        })
    })

    describe('Active property tests', () => {
        it('should throw error for incorrect data type for value', () => {
            const payment = new PaymentPackage('Economic', 100);

            assert.throws(() => payment.active = null, 'Active status must be a boolean');
            assert.throws(() => payment.active = undefined, 'Active status must be a boolean');
            assert.throws(() => payment.active = [], 'Active status must be a boolean');
            assert.throws(() => payment.active = {}, 'Active status must be a boolean');                    
            assert.throws(() => payment.active = 'test', 'Active status must be a boolean');                    
            assert.throws(() => payment.active = 123, 'Active status must be a boolean');                    
        })

        it('should set active property with default value true', () => {
            const payment = new PaymentPackage('Economic', 100);

            assert.isTrue(payment.active);         
        })

        it('should set active property with new input value', () => {
            const payment = new PaymentPackage('Economic', 100);
            payment.active = false;            
            assert.isFalse(payment.active);                   
        })
    })

    describe('toString method tests', () => {
        it('should return right output string with active = false', () => {
            const payment = new PaymentPackage('Economic', 100);
            payment.VAT = 50;
            payment.active = false;

            const expected = ['Package: Economic (inactive)',
                '- Value (excl. VAT): 100',
                `- Value (VAT 50%): 150`]
                .join('\n');

            assert.equal(payment.toString(), expected);                 
        })
        
        it('should return right output string with default value active = true', () => {
            const payment = new PaymentPackage('Economic', 100);
            payment.VAT = 50;           

            const expected = ['Package: Economic',
                '- Value (excl. VAT): 100',
                `- Value (VAT 50%): 150`]
                .join('\n');

            assert.equal(payment.toString(), expected);                 
        })
        
        it('should return right output string with 0', () => {
            const payment = new PaymentPackage('Economic', 0);
            payment.VAT = 0;           

            const expected = ['Package: Economic',
                '- Value (excl. VAT): 0',
                `- Value (VAT 0%): 0`]
                .join('\n');

            assert.equal(payment.toString(), expected);                 
        }) 
    })
});