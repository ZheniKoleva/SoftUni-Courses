function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);   

   function onClick() {
      let searchedWord = document.querySelector('#searchField').value.toLowerCase();
      let rows = Array.from(document.querySelectorAll('tbody tr'));
      rows.forEach(row => row.classList.remove('select'));

      rows.forEach(row => {
         let currentRowColumns = Array.from(row.querySelectorAll('td'));

         if (currentRowColumns.some(x => x.textContent.toLowerCase().includes(searchedWord))) {
            row.classList.add('select');
         }
      });

      searchedWord.value = '';
   }
}