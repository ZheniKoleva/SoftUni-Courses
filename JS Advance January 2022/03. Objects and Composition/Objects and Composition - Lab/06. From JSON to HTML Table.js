function createHTMLTable(inputJson) {   
    let inputData = JSON.parse(inputJson);

    let tableKeys = Object.keys(inputData[0]);

    let result = '<table>';
    result += getColumnsName(tableKeys);

    inputData.forEach(value => {
        let currentValues = Object.values(value);
        result += getColumnsValues(currentValues);
    });

    result += '\n</table>';

    console.log(result);

    function getColumnsName(tableKeys) {
        let columnsData = '\n\t<tr>';
        tableKeys.forEach(key => columnsData += `<th>${escapeFunc(key)}</th>`);
        columnsData += '</tr>';

        return columnsData;
    }

    function getColumnsValues(values) {
        let column = '\n\t<tr>';
        values.forEach(value => column += `<td>${escapeFunc(value)}</td>`);
        column += '</tr>';

        return column;
    }

    function escapeFunc(value) {
        return value
            .toString()
            .replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#39;');
    }
}

createHTMLTable(`[{"Name":"Stamat", "Score":5.5},
 {"Name":"Rumen", "Score":6}]`
);

createHTMLTable(`[{"Name":"Pesho", "Score":4, " Grade":8}, 
{"Name":"Gosho", "Score":5," Grade":8}, 
{"Name":"Angel", "Score":5.50, " Grade":10}]`
);

