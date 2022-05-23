function loadRepos() {
   const request = new XMLHttpRequest();
   request.addEventListener('readystatechange', takeRepos);
   const url = 'https://api.github.com/users/testnakov/repos';

   request.open("GET", url);
   request.send();

   function takeRepos() {      
      const divElement = document.querySelector('#res');

      if (request.readyState == 4 && request.status == 200) {
         divElement.textContent = request.responseText;
      }     
   }  
}
