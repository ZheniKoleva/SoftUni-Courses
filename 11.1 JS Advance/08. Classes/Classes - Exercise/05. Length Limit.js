class Stringer{

    constructor(innerString, initialLength){
        this.innerString = innerString;
        this.innerLength = Number(initialLength);
    }

    increase(length){
        this.innerLength += length;
    }

    decrease(length) {
        this.innerLength = this.innerLength - length < 0
            ? 0
            : this.innerLength - length;
    }

    toString(){
        if(this.innerLength == 0){
            return '...';
        }else if (this.innerString.length > this.innerLength) {
            return this.innerString.substring(0, this.innerLength).concat('...');
        } 

        return this.innerString;
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4); 
console.log(test.toString()); // Test
