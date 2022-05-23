function solve() {
    const [checkButton, clearButtons] = Array.from(document.querySelectorAll('#exercise table tfoot button')); 
        
    checkButton.addEventListener('click', checkField);
    clearButtons.addEventListener('click', clearField);

    const table = document.querySelector('#exercise table');
    const outputText = document.querySelector('#check p'); 

    function checkField() {
        const field = Array.from(table.querySelectorAll('tbody tr'))
            .map(r => Array.from(r.querySelectorAll('td input'))
                .map(c => Number(c.value)));

        const isAllCellsTaken = field.every(row => row.every(digit => digit));

        const isAllRowDigitsDifferent = field
            .every(row => new Set(row).size === 3 && row.every(digit => digit <= 3));

        const isAllColumnDigitsDifferent = field.map((_, i) => {
            return [field[0][i], field[1][i], field[2][i]]
        })
            .every(row => new Set(row).size === 3 && row.every(digit => digit <= 3));

        if (!isAllCellsTaken || !isAllRowDigitsDifferent || !isAllColumnDigitsDifferent) {
            outputText.textContent = 'NOP! You are not done yet...';
            outputText.style.color = 'red';
            table.style.border = '2px solid red';
        }else {
            outputText.textContent = 'You solve it! Congratulations!'; 
            outputText.style.color = 'green';
            table.style.border = '2px solid green';
        }   
    }

    function clearField(){
        Array.from(table.querySelectorAll('tbody tr'))
            .map(r => Array.from(r.querySelectorAll('td input'))
                .map(c => c.value = '')); 

        outputText.textContent = '';       
        table.style.border = 'none';
    }
}