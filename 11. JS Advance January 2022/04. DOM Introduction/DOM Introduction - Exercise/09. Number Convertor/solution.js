function solve() {
    const selectTo = document.querySelector('#selectMenuTo');
    selectTo.appendChild(createOption('Binary'));
    selectTo.appendChild(createOption('Hexadecimal'));

    document.querySelector('button').addEventListener('click', convertData);

    function convertData(){
        const numberToConvert = Number(document.querySelector('#input').value);
        const convertTo = selectTo.value;
        const resultElement = document.querySelector('#result');

        const convertor = {
            binary() {
                return (number) => number.toString(2);
            },
            hexadecimal() {
                return (number) => number.toString(16).toUpperCase();
            },
        }

        resultElement.value = convertor[convertTo]()(numberToConvert);
    }

    function createOption(content){
        const element = document.createElement('option');
        element.value = content.replace(content[0], content[0].toLowerCase());
        element.textContent = content;

        return element;
    }    
}