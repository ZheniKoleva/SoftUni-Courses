
function search() {
   const searchedText = document.querySelector('#searchText');
   const towns = Array.from(document.querySelectorAll('#towns li'));
   const result = document.querySelector('#result');
   let mathesFound = 0;

   towns.forEach(t => {
         if (t.textContent.includes(searchedText.value)) {
            t.style.fontWeight = 'bold';
            t.style.textDecoration = 'underline';
            mathesFound++;
         }else{
            t.style.fontWeight = 'normal';
            t.style.textDecoration = 'none';
         }
   });

   searchedText.value = '';
   result.textContent = `${mathesFound} matches found`;
}
