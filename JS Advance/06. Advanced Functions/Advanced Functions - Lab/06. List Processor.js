function listProcessor(input){ 
    debugger
    let resultArray = [];
    const innerObject = {
        add,
        remove,
        print
    };    

    input.forEach(x => {
        const [command, value] = x.split(' ');
        innerObject[command](value);
    });
   
    function add(string){
        resultArray.push(string);
    }

    function remove(string){
        resultArray = resultArray.filter(x => x != string);
    }

    function print(){
        console.log(resultArray.join(','));
    }
}

listProcessor(['add hello', 'add again', 'remove hello', 'add again', 'print']);
listProcessor(['add pesho', 'add george', 'add peter', 'remove peter','print']);