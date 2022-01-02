function calc() {
    //option 1
    let firstNum = Number(document.querySelector('#num1').value);
    let secondNum = Number(document.querySelector('#num2').value);
    
    let result = document.querySelector('#sum');
    result.value = firstNum + secondNum;   
    
    //option 2
    let firstNum = Number(document.getElementById('num1').value);
    let secondNum = Number(document.getElementById('num2').value);
    
    let result = document.getElementById('sum');
    result.value = firstNum + secondNum;   
}
