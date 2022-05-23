function convertJSONToHTMLTable(inputArray){
    let data = JSON.parse(inputArray);
    
    let output = ["<table>"];
    output.push(makeKeyRow(data));
    data.forEach((rowData) => output.push(makeValueRow(rowData)));
    output.push("</table>");

    console.log(output.join('\n'));

    function makeKeyRow(data){
       let result = '   <tr>';

       let columnNames = Object.keys(data[0]);
       columnNames.forEach(key => {
           result += `<th>${escapeFunc(key)}</th>`;
       });
        
       result += '</tr>';
       return result;
    };

    function makeValueRow(rowData){ 
        let result = '   <tr>';

        let columnNames = Object.values(rowData);
        columnNames.forEach(value => {
            result += `<td>${escapeFunc(value)}</td>`;
        });
         
        result += '</tr>';
        return result;
    };

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

convertJSONToHTMLTable(`[
    {"Name":"Stamat", "Score":5.5},
    {"Name":"Rumen", "Score":6}
]`);

convertJSONToHTMLTable(`[
    {"Name":"Pesho", "Score":4, " Grade":8},
    {"Name":"Gosho", "Score":5, " Grade":8},
    {"Name":"Angel", "Score":5.50, " Grade":10}
]`);

