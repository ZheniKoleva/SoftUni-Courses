function generateReport() {
    const resultElement = document.querySelector('#output');
    const chosenColums = {};

    Array.from(document.querySelectorAll('table thead tr th'))
        .forEach((th, index) => {
            if (th.querySelector('input[type="checkbox"]').checked) {
                chosenColums[index] = th.querySelector('input').name;;
            }
        });

    const infoToReport = Array
        .from(document.querySelectorAll('table tbody tr'))
        .map(row => {
            const rowInfo = {};
            const rowChildren = Array.from(row.children);

            rowChildren.forEach((c, index) => {
                if (chosenColums.hasOwnProperty(index)) {
                    const key = chosenColums[index];
                    rowInfo[key] = c.textContent;
                }
            });

            return rowInfo;
        });

     resultElement.textContent = JSON.stringify(infoToReport, null, 2);   
}