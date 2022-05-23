const {assert, expect } = require('chai');
const companyAdministration = require('../03. Company Administration/companyAdministration.js');

describe("companyAdministration Tests", function() {
    describe("hiringEmployee tests", function() {
        it("should validate hiringEmployee is a function", function() {
            assert.isFunction(companyAdministration.hiringEmployee);
        });

        it("should throw error if position different from Programmer is applied", function() {
            const message  = `We are not looking for workers for this position.`;
            assert.throws(() => companyAdministration.hiringEmployee('Pesho', 'SysAdmin', 10), Error, message);
        });

        it("should hire applicant if position is Programmer and has experience equal or above 3 years", function() {
            const name = 'Pesho';
            const position = 'Programmer';
            const experience = 3;
            const experience2 = 10;            
            
            const expect  = `${name} was successfully hired for the position ${position}.`;
            const actual = companyAdministration.hiringEmployee(name, position, experience);
            assert.equal(actual, expect);

            const actual2 = companyAdministration.hiringEmployee(name, position, experience2);
            assert.equal(actual2, expect);
        });

        it("should not approve applicant if position is Programmer and has experience less than 3 years", function() {
            const name = 'Pesho';
            const position = 'Programmer';
            const experience = 2;
            const experience2 = 0;            
            
            const expect  = `${name} is not approved for this position.`;
            const actual = companyAdministration.hiringEmployee(name, position, experience);
            assert.equal(actual, expect);

            const actual2 = companyAdministration.hiringEmployee(name, position, experience2);
            assert.equal(actual2, expect);
        });
     });


     describe("calculateSalary tests", function() {
        it("should validate calculateSalary is a function", function() {
            assert.isFunction(companyAdministration.calculateSalary);
        });

        it("should throw error if hours parameter is not a number or is a negative number", function() {            
            const message = 'Invalid hours';
            
            assert.throws(() => companyAdministration.calculateSalary('123'), Error, message);
            assert.throws(() => companyAdministration.calculateSalary([]), Error, message);
            assert.throws(() => companyAdministration.calculateSalary(true), Error, message);
            assert.throws(() => companyAdministration.calculateSalary({}), Error, message);

            assert.throws(() => companyAdministration.calculateSalary(-1), Error, message);
            assert.throws(() => companyAdministration.calculateSalary(-1.23), Error, message);
        });

        it("should return salary if has no overtime (hours less than or equal to 160)", function() {
            let payPerHour = 15;

            const actual = companyAdministration.calculateSalary(160);
            const expected = 160 * payPerHour;
            assert.equal(actual, expected);

            const actual2 = companyAdministration.calculateSalary(1);
            const expected2 = 1 * payPerHour;
            assert.equal(actual2, expected2);           

            const actual3 = companyAdministration.calculateSalary(10.5);
            const expected3 = 10.5 * payPerHour;
            assert.equal(actual3, expected3);

            const actual4 = companyAdministration.calculateSalary(0);
            const expected4 = 0 * payPerHour;
            assert.equal(actual4, expected4);
        });

        it("should return salary plus bonus 1000 if has overtime (hours above 160)", function() {
            let payPerHour = 15;
            let bonus = 1000;

            const actual = companyAdministration.calculateSalary(161);
            const expected = (161 * payPerHour) + bonus;
            assert.equal(actual, expected);

            const actual2 = companyAdministration.calculateSalary(200);
            const expected2 = (200 * payPerHour) + bonus;
            assert.equal(actual2, expected2);            
        });
     });

     describe("firedEmployee tests", function() {
        it("should validate firedEmployee is a function", function() {
            assert.isFunction(companyAdministration.calculateSalary);
        });

        it("should throw error if employees parameter is not an array", function() {            
            const message = 'Invalid input';
            
            assert.throws(() => companyAdministration.firedEmployee(123, 1), Error, message);
            assert.throws(() => companyAdministration.firedEmployee('test', 1), Error, message);
            assert.throws(() => companyAdministration.firedEmployee({}, 1), Error, message);
            assert.throws(() => companyAdministration.firedEmployee(true, 1), Error, message);            
        });

        it("should throw error if index parameter is not a integer number", function() {            
            const message = 'Invalid input';
            const employees = ['Pesho', 'Gosho', 'Stamat', 'Evlogi'];
            
            assert.throws(() => companyAdministration.firedEmployee(employees, '1'), Error, message);
            assert.throws(() => companyAdministration.firedEmployee(employees, 'test'), Error, message);
            assert.throws(() => companyAdministration.firedEmployee(employees, 1.23), Error, message);
            assert.throws(() => companyAdministration.firedEmployee(employees, true), Error, message);            
            assert.throws(() => companyAdministration.firedEmployee(employees, {}), Error, message);            
        });

        it("should throw error if index parameter is out of employees array length", function() {            
            const message = 'Invalid input';
            const employees = ['Pesho', 'Gosho', 'Stamat', 'Evlogi'];
            
            assert.throws(() => companyAdministration.firedEmployee(employees, -1), Error, message);
            assert.throws(() => companyAdministration.firedEmployee(employees, 4), Error, message);
            assert.throws(() => companyAdministration.firedEmployee(employees, 10), Error, message);
            assert.throws(() => companyAdministration.firedEmployee(employees, -10), Error, message);           
        });

        it("should return employees without the employee on the index parameter", function() {
            const employees = ['Pesho', 'Gosho', 'Stamat', 'Evlogi'];

            const actual = companyAdministration.firedEmployee(employees, 1);
            const expected = 'Pesho, Stamat, Evlogi';            
            assert.deepEqual(actual, expected);

            const actual2 = companyAdministration.firedEmployee(employees, 0);
            const expected2 = 'Gosho, Stamat, Evlogi';            
            assert.deepEqual(actual2, expected2);

            const actual3 = companyAdministration.firedEmployee(employees, 3);
            const expected3 = 'Pesho, Gosho, Stamat';            
            assert.deepEqual(actual3, expected3);
        });
     });
     
});
