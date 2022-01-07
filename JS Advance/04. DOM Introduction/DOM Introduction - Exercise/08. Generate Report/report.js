function generateReport() {
    let checkedBox = {};

    let columnsChecked = Array.from(document.querySelectorAll('thead tr th'))
        .forEach((column, i) => {
            if (column.querySelector('input').checked) {
                checkedBox[i] = column.querySelector('input').name;
            }
        });
    ;

    let dataToExport = Array.from(document.querySelectorAll('tbody tr'))
        .map(row => {
            let rowsData = {};

            let children = Array.from(row.querySelectorAll('td'))
                .forEach((td, i) => {
                    if (checkedBox.hasOwnProperty(i)) {
                        rowsData[checkedBox[i]] = td.textContent;
                    }
                });

            return rowsData;
        });


    document.querySelector('#output').textContent = JSON.stringify(dataToExport, null, 2);

}