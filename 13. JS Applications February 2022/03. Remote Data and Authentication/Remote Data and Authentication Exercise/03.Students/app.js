const resultTable = document.querySelector('#results tbody');
const formElement = document.querySelector('#form');
formElement.addEventListener('submit', createStudent);

window.onload = loadStudents();

async function createStudent(e) {
    e.preventDefault();    

    const url = 'http://localhost:3030/jsonstore/collections/students';
    const formData = new FormData(e.target);
    const studentData = Object.fromEntries(formData);

    try {
        validateStudentInputData(studentData);
        formElement.reset();

        const options = {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(studentData)
        };

        const response = await fetch(url, options);
        validateResponse(response);
        const data = await response.json();
        
        const rowElement = createStudentData(data);
        resultTable.append(rowElement);

    } catch (error) {
        alert(error.message);
    }
}

async function loadStudents() {    
    resultTable.replaceChildren();

    const url = 'http://localhost:3030/jsonstore/collections/students';

    try {
        const response = await fetch(url);

        validateResponse(response);       

        const data = await response.json();

        Object.values(data)
            .forEach(x => {
                const row = createStudentData(x);
                resultTable.appendChild(row);
            });

    } catch (error) {
        alert(error.message);
    }
}

function createStudentData(studentInfo) {
    const rowElement = document.createElement('tr');

    Object.values(studentInfo)
        .slice(0, Object.values(studentInfo).length - 1)
        .forEach(x => {
            const trElement = document.createElement('td');
            trElement.textContent = x;
            rowElement.append(trElement);
        });

    return rowElement;
}

function validateStudentInputData(studentData) {
    const regex = /^\d+$/g;
    const gradeRegex = /[2-6]/;

    if (Object.values(studentData).some(x => !x)) {
        throw new Error('Please, fill all the fields!');
    }

    if (!regex.test(studentData.facultyNumber)) {
        throw new Error('Faculty number should consist of digits only');
    }

    if (!gradeRegex.test(studentData.grade)) {
        throw new Error('Grade should be a digit between 2 and 6');
    }else {
        studentData.grade = Number(studentData.grade).toFixed(2);
    }
}

function validateResponse(response) {
    if (response.status !== 200) {
        throw new Error('Something went wrong! Please, try again');
    }
}