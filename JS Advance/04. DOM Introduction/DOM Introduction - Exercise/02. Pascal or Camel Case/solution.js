function solve() {
  const conventions = ['Camel Case', 'Pascal Case'];
  
  const textToConvert = document.querySelector('#text').value.split(' ');
  const convention = document.querySelector('#naming-convention').value;

  let result = '';

  if (!conventions.includes(convention)) {
    result = 'Error!';
  } else {
    result = textToConvert
      .map(x => transformWords(x))
      .join('');
  }

  if (convention === conventions[0]) {
    result = result[0].toLowerCase() + result.slice(1);
  }

  document.querySelector('#result').textContent = result;

  function transformWords(input){
      return input[0].toUpperCase() + input.slice(1).toLowerCase();
  } 
}