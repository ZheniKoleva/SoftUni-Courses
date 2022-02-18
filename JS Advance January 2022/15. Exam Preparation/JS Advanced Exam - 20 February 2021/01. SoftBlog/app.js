function solve() {
   const postsSection = document.querySelector('.site-content main > section');
   const formArea = document.querySelector('form');
   const archiveSection = document.querySelector('.archive-section ol');
   document.querySelector('button.btn.create').addEventListener('click', createPost);

   function createPost(e) {
      e.preventDefault();

      const authorInput = formArea.querySelector('#creator');
      const titleInput = formArea.querySelector('#title');
      const categoryInput = formArea.querySelector('#category');
      const contentInput = formArea.querySelector('#content');

      const articleElement = createElement('article', undefined);

      const h1Element =  createElement('h1', titleInput.value);      

      const pCategoryElement = createElement('p', 'Category:');      

      const strongCategoryElement = createElement('strong', categoryInput.value);     
      pCategoryElement.appendChild(strongCategoryElement);

      const pCreatorElement = createElement('p', 'Creator:');
     
      const strongCreatorElement = createElement('strong', authorInput.value);     
      pCreatorElement.appendChild(strongCreatorElement);

      const pContentElement = createElement('p', contentInput.value);
     
      const divElement = document.createElement('div');
      divElement.classList.add('buttons');

      const deleteButton = createElement('button', 'Delete');     
      deleteButton.classList.add('btn', 'delete');
      deleteButton.addEventListener('click', deleteArticle);

      const archiveButton = createElement('button', 'Archive');    
      archiveButton.classList.add('btn', 'archive');
      archiveButton.addEventListener('click', archiveArticle);
      divElement.appendChild(deleteButton);
      divElement.appendChild(archiveButton);

      articleElement.appendChild(h1Element);
      articleElement.appendChild(pCategoryElement);
      articleElement.appendChild(pCreatorElement);
      articleElement.appendChild(pContentElement);
      articleElement.appendChild(divElement);

      postsSection.appendChild(articleElement);

      titleInput.value = '';
      categoryInput.value = '';
      authorInput.value = '';
      contentInput.value = '';
   }

   function deleteArticle(e) {
      const articleToDelete = e.target.parentElement.parentElement;
      articleToDelete.remove();
   }

   function archiveArticle(e) {
      const articleToArhive = e.target.parentElement.parentElement;
      const articleTitle = articleToArhive.querySelector('h1').textContent;
      articleToArhive.remove();

      const liElement = createElement('li', articleTitle);
     
      archiveSection.appendChild(liElement);

      Array.from(archiveSection.children)
         .sort((a, b) => a.textContent.localeCompare(b.textContent))
         .forEach(x => archiveSection.appendChild(x));
   }

   function createElement(type, textContent){
      const element = document.createElement(type);
      element.textContent = textContent;

      return element;
   }
}
