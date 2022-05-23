function subtract() {    
    const firstNumber = Number(document.querySelector('#firstNumber').value);
    const secondNumber = Number(document.querySelector('#secondNumber').value);

    const result = firstNumber - secondNumber;
    
    document.querySelector('#result').textContent = result;
}