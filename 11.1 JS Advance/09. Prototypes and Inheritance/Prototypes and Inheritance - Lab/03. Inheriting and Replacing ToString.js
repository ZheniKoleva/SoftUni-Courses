function toStringExtension() {
    class Person {
        constructor(name, email) {
            this.name = name;
            this.email = email;
        }

        toString() {
            return `${this.constructor.name} (name: ${this.name}, email: ${this.email})`
        }
    }

    class Teacher extends Person {
        constructor(name, email, subject) {
            super(name, email);
            this.subject = subject;
        }

        toString(){
            return super.toString().slice(0, -1).concat(`, subject: ${this.subject})`);
        }
    }

    class Student extends Person {
        constructor(name, email, course) {
            super(name, email);
            this.course = course;
        }

        toString(){
            return super.toString().slice(0, -1).concat(`, course: ${this.course})`);
        }
    }

    return {
        Person,
        Teacher,
        Student
    }
}

let classes = toStringExtension();
let person = new classes.Person('Ivan', 'abc@abc.bg');

console.log(person.toString());

let student = new classes.Student('Dragan', 'qwe@asd.zx', 'math');
console.log(student.toString());

let classes2 = toStringExtension();
let Person = classes2.Person;
let Teacher = classes2.Teacher;
let Student = classes2.Student;

let t = new Teacher("Ivan",'ivan@ivan.com',"Graphics");
console.log(t.toString());