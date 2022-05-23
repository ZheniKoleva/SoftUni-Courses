function calc() {
   const firstNum = Number(document.querySelector('#num1').value);
   const secondNum = Number(document.querySelector('#num2').value);

   document.querySelector('#sum').value = firstNum + secondNum;
}
