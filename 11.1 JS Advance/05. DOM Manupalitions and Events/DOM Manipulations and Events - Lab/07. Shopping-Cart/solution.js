function solve() {
   let products = [];

   let textArea = document.querySelector('textarea');

   let shoppingCart = document.querySelector('.shopping-cart');
   shoppingCart.addEventListener('click', buyProducts);

   let checkoutButton = document.querySelector('.checkout');
   checkoutButton.addEventListener('click', getBill); 

   function buyProducts(e){

      if (e.target.tagName == 'BUTTON' && e.target.classList.contains('add-product')) {
         let parent = e.target.parentElement.parentElement;
         let productName = parent.querySelector('.product-title').textContent;
         let productPrice = Number(parent.querySelector('.product-line-price').textContent);
         let boughtProduct = `Added ${productName} for ${productPrice.toFixed(2)} to the cart.\n`;
   
         products.push({productName, productPrice});          
         textArea.textContent += boughtProduct;
      }     
   }

   function getBill() {
      let uniqueProducts = new Set();
      products.forEach(p => uniqueProducts.add(p.productName));
      let totalSum = products.reduce((s, p) => s + p.productPrice, 0);

      let result = `You bought ${Array.from(uniqueProducts).join(', ')} for ${totalSum.toFixed(2)}.`;

      textArea.textContent += result;
      Array.from(document.querySelectorAll('button'))
         .forEach(b => b.disabled = true);
   }
}