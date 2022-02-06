(function stringExtensions(){

    String.prototype.ensureStart = function(str){
        if (!this.startsWith(str)) {
            return str.concat(this);
        }

        return this.toString();
    }

    String.prototype.ensureEnd = function(str){
        if (!this.endsWith(str)) {
            return this.concat(str);
        }

        return this.toString();
    }

    String.prototype.isEmpty = function(){        
        return this.toString() === '';
    }

    String.prototype.truncate = function(n){
        if(n < 4) {
            return '.'.repeat(n);
        }        
        
        if (this.length <= n) {
            return this.toString();
        }

        const words = this.toString().split(' ');

        if(words.length === 1) {            
            return this.toString().slice(0, n - 3).concat('...');
        }

        while (words.join(' ').length + 3 > n) {
            words.pop();
        }

        return words.join(' ').concat('...');        
    }


    String.format = function(string, ...params) {

        for (let i = 0; i < params.length; i++) {
            string = string.replace(`{${i}}`, params[i]);
        }

        return string;
    }

}());


let str = 'my string';
str = str.ensureStart('my');
console.log(str);
str = str.ensureStart('hello ');
console.log(str);
str = str.truncate(16);
console.log(str);
str = str.truncate(14);
console.log(str);
str = str.truncate(8);
console.log(str);
str = str.truncate(4);
console.log(str);
str = str.truncate(2);
console.log(str);
str = String.format('The {0} {1} fox',
  'quick', 'brown');
  console.log(str);
str = String.format('jumps {0} {1}',
  'dog');
  console.log(str);
