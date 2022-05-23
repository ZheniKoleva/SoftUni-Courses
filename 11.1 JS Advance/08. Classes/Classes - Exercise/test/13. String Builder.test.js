const {assert, expect} = require('chai');
const StringBuilder = require('../13. String Builder');

describe('String Builder Tests', () => {
    describe('constructor tests', () => {
        it('should initialise empty array if input is undefined', () => {
            const sb = new StringBuilder(undefined);

            expect(sb.toString()).to.be.equal('');
            expect(sb).to.be.instanceOf(StringBuilder);
        })

        it('should throws error if input is not undefined and is not string', () => {            
            expect(() => new StringBuilder(1)).to.throw(TypeError, 'Argument must be a string');
            expect(() => new StringBuilder([])).to.throw(TypeError, 'Argument must be a string');
            expect(() => new StringBuilder({})).to.throw(TypeError, 'Argument must be a string');
            expect(() => new StringBuilder(true)).to.throw(TypeError, 'Argument must be a string');
            expect(() => new StringBuilder(1.23)).to.throw(TypeError, 'Argument must be a string');
            expect(() => new StringBuilder(null)).to.throw(TypeError, 'Argument must be a string');            
        })

        it('should return string with same length after join of the initial string transformed into array', () => { 
            const sb = new StringBuilder('test');
            const sb2 = new StringBuilder('123 45')

            expect(sb._stringArray).to.be.deep.equal(['t', 'e', 's', 't']);
            expect(sb.toString().length).to.be.equal(4);                      
            expect(sb2.toString().length).to.be.equal(6);                      
        })
    })

    describe('append tests', () => {       
        it('should throws error if input is not string', () => { 
            const sb = new StringBuilder('test');  

            expect(() => sb.append(1)).to.throw(TypeError, 'Argument must be a string');
            expect(() => sb.append({})).to.throw(TypeError, 'Argument must be a string');
            expect(() => sb.append([])).to.throw(TypeError, 'Argument must be a string');
            expect(() => sb.append(true)).to.throw(TypeError, 'Argument must be a string');
            expect(() => sb.append(1.23)).to.throw(TypeError, 'Argument must be a string');
            expect(() => sb.append(null)).to.throw(TypeError, 'Argument must be a string');            
            expect(() => sb.append(undefined)).to.throw(TypeError, 'Argument must be a string');            
        })

        it('should append string to existing string', () => { 
            const sb = new StringBuilder('test');
            const textToAppend = ' class';
            const expected = 'test class';
            sb.append(textToAppend);

            expect(sb.toString()).to.be.equal(expected); 
            expect(sb.toString().length).to.be.equal(10);                              
        })
    })

    describe('prepend tests', () => {       
        it('should throws error if input is not string', () => { 
            const sb = new StringBuilder('test');  

            expect(() => sb.prepend(1)).to.throw(TypeError, 'Argument must be a string');
            expect(() => sb.prepend({})).to.throw(TypeError, 'Argument must be a string');
            expect(() => sb.prepend([])).to.throw(TypeError, 'Argument must be a string');
            expect(() => sb.prepend(true)).to.throw(TypeError, 'Argument must be a string');
            expect(() => sb.prepend(1.23)).to.throw(TypeError, 'Argument must be a string');
            expect(() => sb.prepend(null)).to.throw(TypeError, 'Argument must be a string');            
            expect(() => sb.prepend(undefined)).to.throw(TypeError, 'Argument must be a string');            
        })

        it('should prepend string to existing string', () => { 
            const sb = new StringBuilder('test');
            const textToAppend = 'new ';
            const expected = 'new test';
            sb.prepend(textToAppend);

            expect(sb.toString()).to.be.equal(expected); 
            expect(sb.toString().length).to.be.equal(8);                              
        })
    })

    describe('insertAt tests', () => {       
        it('should throws error if input is not string', () => { 
            const sb = new StringBuilder('test');  

            expect(() => sb.insertAt(1, 0)).to.throw(TypeError, 'Argument must be a string');
            expect(() => sb.insertAt({}, 0)).to.throw(TypeError, 'Argument must be a string');
            expect(() => sb.insertAt([], 0)).to.throw(TypeError, 'Argument must be a string');
            expect(() => sb.insertAt(true, 0)).to.throw(TypeError, 'Argument must be a string');
            expect(() => sb.insertAt(1.23, 0)).to.throw(TypeError, 'Argument must be a string');
            expect(() => sb.insertAt(null, 0)).to.throw(TypeError, 'Argument must be a string');            
            expect(() => sb.insertAt(undefined, 0)).to.throw(TypeError, 'Argument must be a string');            
        })

        it('should insert string to the index', () => { 
            const sb = new StringBuilder('new test');
            const textToInsert = ' stupid';
            const expected = 'new stupid test';
            sb.insertAt(textToInsert, 3);

            expect(sb._stringArray).to.deep.equal(['n', 'e', 'w', ' ', 's', 't', 'u', 'p', 'i', 'd', ' ', 't', 'e', 's', 't']);
            expect(sb.toString()).to.be.equal(expected); 
            expect(sb.toString().length).to.be.equal(15); 
            
            const textToInsert2 = ' again';
            const expected2 = 'new stupid test again';
            sb.insertAt(textToInsert2, sb.toString().length);
            expect(sb.toString()).to.be.equal(expected2); 
            expect(sb.toString().length).to.be.equal(21); 

        })
    })

    describe('remove tests', () => {
        it('should remove string with defined length', () => { 
            const sb = new StringBuilder('new stupid test again');            
            const expected = 'new  test again';
            sb.remove(4, 6);

            expect(sb.toString()).to.be.equal(expected); 
            expect(sb.toString().length).to.be.equal(15);             
            
            const expected2 = 'new test again';
            sb.remove(3, 1);
            expect(sb.toString()).to.be.equal(expected2); 
            expect(sb.toString().length).to.be.equal(14);
        })
    })

    describe('toString tests', () => {
        it('should return string as expected', () => { 
            const sb = new StringBuilder('test'); 
            const expected = 'this is  the final test';
            sb.prepend('this is ');
            
            const textToInsertAt = ' the final ';
            sb.insertAt(textToInsertAt, 8);

            expect(sb.toString()).to.be.equal(expected);

            sb.remove(7, 1);
            const expected2 = 'this is the final test';

            expect(sb.toString()).to.be.equal(expected2);

            const textToAppend = ' ever!';
            const expected3 = 'this is the final test ever!';
            sb.append(textToAppend);

            expect(sb.toString()).to.be.equal(expected3);
        })
    })
})