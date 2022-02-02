class Hex{
    constructor(value){
        this.value = Number(value);
    }

    valueOf(){
        return this.value;
    }

    toString(){
        return `0x${this.value.toString(16).toUpperCase()}`;
    }

    plus(obj){
        if (Number(obj)) {
            return new Hex(this.value + obj);
        }
        
        return new Hex(this.value + obj.valueOf());
    }

    minus(obj){
        if (Number(obj)) {
            return new Hex(this.value - obj);
        }
        
        return new Hex(this.value - obj.valueOf());
    }

    parse(string){
        return parseInt(string, 16);
    }
}

let FF = new Hex(255);
console.log(FF.toString());
FF.valueOf() + 1 == 256;
let a = new Hex(10);
let b = new Hex(5);
console.log(a.plus(b).toString());
console.log(a.plus(b).toString()==='0xF');
console.log(FF.parse('AAA'));

