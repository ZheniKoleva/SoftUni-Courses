function calculator() {
    let [num1Element, num2Element, resultElement] = '';

    const calculate = {
        init,
        add,
        subtract
    };

    return calculate;

    function subtract(){
        const result = Number(num1Element.value) - Number(num2Element.value);
        resultElement.value = result;
    }

    function add(){
        const result = Number(num1Element.value) + Number(num2Element.value);
        resultElement.value = result;
    }

    function init(selector1, selector2, resultSelector){
        num1Element = document.querySelector(selector1);
        num2Element = document.querySelector(selector2);
        resultElement = document.querySelector(resultSelector);        
    }
}

const calculate = calculator (); 
calculate.init ('#num1', '#num2', '#result'); 





