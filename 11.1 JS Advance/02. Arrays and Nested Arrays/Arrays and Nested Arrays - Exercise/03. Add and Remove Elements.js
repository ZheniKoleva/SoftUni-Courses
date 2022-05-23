function addRemoveElements(commandsArray){
    let initialNumber = 1;
    let resultArray = [];

    for (const command of commandsArray) {
       
        switch (command) {
            case 'add':
                resultArray.push(initialNumber);
                break;

            case 'remove':
                resultArray.pop();
                break;
       }
        
       initialNumber++;
    };

    resultArray.length === 0 
        ? console.log('Empty')
        : resultArray.forEach(x => console.log(x));   
}

addRemoveElements(['add', 
'add', 
'add', 
'add']);

addRemoveElements(['add', 
'add', 
'remove', 
'add', 
'add']);

addRemoveElements(['remove', 
'remove', 
'remove']);