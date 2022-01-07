function search() {
   let searchedText = document.querySelector('#searchText').value.toLowerCase();
  
   let towns = Array.from(document.querySelectorAll('#towns li'));
   let townsFound = 0;

   for (const town of towns) {

      if (town.textContent.toLowerCase().includes(searchedText)) {
         townsFound++;
         town.style.textDecoration = 'underline';
         town.style.fontWeight = 'bold'; 
                 
      } else {        
         town.style.textDecoration = 'none';
         town.style.fontWeight = 'normal';
      }
   }

   document.querySelector('#result').textContent = `${townsFound} matches found`;
}
