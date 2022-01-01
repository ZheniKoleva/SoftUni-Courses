function createSortedList(){
    const list = [];
    
    return {        
        get size(){
            return list.length;
        },
        add: function add(number){
            list.push(number);
            list.sort((a,b) => a - b);
        },
        remove: function remove(index){
            if (index < 0 || index >= list.length) {
                throw new RangeError('Index is out of range');
            } 
            
           list.splice(index, 1);
           list.sort((a,b) => a - b);
        },
        get: function get(index){
            if(index < 0 || index >= list.length){
                throw new RangeError('Index is out of range');
            }   
            
            return list[index];
        }
    }
}

let list = createSortedList();
list.add(5);
list.add(6);
list.add(7);
console.log(list.size);
console.log(list.get(1)); 
list.remove(1);
console.log(list.get(1));
console.log(list.size);


