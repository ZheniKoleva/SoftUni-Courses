import * as validations from './validations.js';
import { createRow } from './create.js';


async function solve() {
  const tableBody = document.querySelector('#table-body');  

  const url = 'http://localhost:3030/data/furniture';

  try {
    const response = await fetch(url);
    validations.validateResponse(response);

    const data = await response.json();    

    Object.values(data)
      .forEach(x => {
        const row = createRow(x);
        row.querySelector('input[type="checkbox"]').disabled = true;
        tableBody.append(row);
      });


  } catch (error) {
    alert(error.message);
  }
}

solve();