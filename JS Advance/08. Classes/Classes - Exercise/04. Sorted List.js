class List{  
    constructor(){
        this.innerList = [];
        this.size = 0;
    }   

    get(index){
        if (index < 0 || index > this.innerList.length - 1) {
            throw new RangeError('Index out of range');
        }

        return this.innerList[index];
    }

    add(element){
        this.innerList.push(element);
        this.innerList.sort((a, b) => a - b);
        this.size++;
    }

    remove(index){
        if (index < 0 || index > this.innerList.length - 1) {
            throw new RangeError('Index out of range');
        }

        this.innerList.splice(index, 1);
        this.size--;
    }
}

let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1)); 
list.remove(1);
console.log(list.get(1));
