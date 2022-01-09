function solve() {        
    let toInsert = document.querySelector('#selectMenuTo');

    let hexadecimalElement = document.createElement('option');
    hexadecimalElement.value = 'hexadecimal';
    hexadecimalElement.textContent = 'Hexadecimal';
    toInsert.appendChild(hexadecimalElement);

    let binaryElement = document.createElement('option');
    binaryElement.value = 'binary';
    binaryElement.textContent = 'Binary';
    toInsert.appendChild(binaryElement);

    document.querySelector('button').addEventListener('click', convert);
    
    function convert(){
        let numberToConvert = Number(document.querySelector('#input').value);
        let toConvertInto = document.querySelector('#selectMenuTo').value;
        let result = {
            binary(){
                return numberToConvert.toString(2);
            },
            hexadecimal(){
                return numberToConvert.toString(16).toUpperCase();
            }
        } 
        
        document.querySelector('#result').value = result[toConvertInto]();
    } 
}