function addOrRemoveElements(inputArray) {
    let initialNumber = 1;
    let result = [];
   
    const operation = {
        add() { result.push(initialNumber)},
        remove() {result.pop()}
    };

    inputArray.forEach(x => {
        operation[x]();
        initialNumber++;
    })

    result.length == 0
        ? console.log('Empty')
        : result.forEach(x => console.log(x));
}

addOrRemoveElements(['add', 'add', 'add', 'add']);

addOrRemoveElements(['add', 'add', 'remove', 'add', 'add']);

addOrRemoveElements(['remove', 'remove', 'remove']);