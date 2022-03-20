import { towns } from './towns.js';
import { townsTemplate, resultTemplate } from './templates/templates.js';
import { render } from './../node_modules/lit-html/lit-html.js';

const townsRoot = document.querySelector('#towns');
const inputField = document.querySelector('#searchText');
const resultDiv = document.querySelector('#result');
const searchButton = document.querySelector('button');
searchButton.addEventListener('click', search);

let townsToShow = towns.map(x => {return { name: x }});
render(townsTemplate(townsToShow), townsRoot);

function search() {
   const searchedText = inputField.value.toLowerCase();  

   townsToShow = towns.map(x => {return { name: x }});
   const filtered = townsToShow
      .filter(x => x.name.toLowerCase().includes(searchedText));
   filtered.forEach(x => x.class = 'active');
   const matchesCount = filtered.length;

   render(townsTemplate(townsToShow), townsRoot);
   render(resultTemplate(matchesCount), resultDiv);   
}

