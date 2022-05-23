class Company {
    constructor() {
        this.departments = {};
    }

    addEmployee(name, salary, position, department) {
        if ([...arguments].some(x => !x) || Number(salary) < 0) {
            throw new Error('Invalid input!');
        }

        const employee = {
            name: name,
            salary: Number(salary),
            position: position,
        };

        if (!this.departments.hasOwnProperty(department)) {
            this.departments[department] = {
                employees: [],
                avgSalary() {
                    return (this.employees
                        .reduce((a, b) => a + b.salary, 0) / this.employees.length) || 0;
                },
            };
        }

        this.departments[department].employees.push(employee);

        return `New employee is hired. Name: ${name}. Position: ${position}`;
    }

    bestDepartment() {
        const departmentsNames = Object.keys(this.departments)
            .sort((a, b) => this.departments[b].avgSalary() - this.departments[a].avgSalary());

        const bestDepartmentName = departmentsNames[0];
        const bestDepartment = `Best Department is: ${bestDepartmentName}`;
        const averageSalary = `Average salary: ${this.departments[bestDepartmentName].avgSalary().toFixed(2)}`;
        const employees = this.departments[bestDepartmentName].employees
            .sort((a, b) => b.salary - a.salary || a.name.localeCompare(b.name))
            .map(e => `${e.name} ${e.salary} ${e.position}`)
            .join('\n');

        return `${bestDepartment}\n${averageSalary}\n${employees}`;
    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());
