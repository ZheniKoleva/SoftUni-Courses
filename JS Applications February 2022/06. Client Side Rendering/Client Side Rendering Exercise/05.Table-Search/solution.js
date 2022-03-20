import { render } from './../node_modules/lit-html/lit-html.js';
import { rowTemplate } from './templates/templates.js';

const tableBody = document.querySelector('.container tbody');
const searchField = document.querySelector('#searchField');
const searchButton = document.querySelector('#searchBtn');
searchButton.addEventListener('click', onClick);

const studentsToLoad = await getStudents();
render(rowTemplate(studentsToLoad), tableBody);

function onClick() {
   const textToSearch = searchField.value.toLowerCase();
   searchField.value = '';

   const students = studentsToLoad.map(x => Object.assign({}, x));
   const filtered = students
      .filter(x => Object.values(x).some(x => x.toLowerCase().includes(textToSearch)));
   filtered.forEach(x => x.class = 'select');

   render(rowTemplate(students), tableBody);
}


async function getStudents() {
   const response = await fetch('http://localhost:3030/jsonstore/advanced/table');
   const data = await response.json();
   const students = Object.values(data)
      .map(x => ({
         name: `${x.firstName} ${x.lastName}`,
         email: x.email,
         course: x.course
      }));

   return students;
}