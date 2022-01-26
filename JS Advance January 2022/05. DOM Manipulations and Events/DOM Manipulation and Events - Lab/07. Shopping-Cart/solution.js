function solve() {
   const productsArea = document.querySelector('.shopping-cart');
   productsArea.addEventListener('click', buyProducts);

   const checkoutButton = document.querySelector('button.checkout');
   checkoutButton.addEventListener('click', calculateBill);

   const textArea = document.querySelector('textarea');

   const boughtProducts = {};

   function buyProducts(e) {
      if (e.target.tagName != 'BUTTON' || !e.target.classList.contains('add-product')) {
         return;
      }

      const parent = e.target.parentElement.parentElement;
      const productName = parent.querySelector('.product-title').textContent;
      const productPrice = Number(parent.querySelector('.product-line-price').textContent);

      if (!boughtProducts.hasOwnProperty(productName)) {
         boughtProducts[productName] = {
            price: productPrice,
            quantity: 0,
         };
      }

      boughtProducts[productName].quantity++;

      textArea.textContent += `Added ${productName} for ${productPrice.toFixed(2)} to the cart.\n`;
   }

   function calculateBill(e) {
      Array.from(document.querySelectorAll('button'))
         .forEach(b => b.disabled = true);

      const products = Object.keys(boughtProducts).join(', ');
      const totalPrice = Object.values(boughtProducts)
         .reduce((a, b) => a + (b.quantity * b.price), 0);

      textArea.textContent += `You bought ${products} for ${totalPrice.toFixed(2)}.`;
   }
}