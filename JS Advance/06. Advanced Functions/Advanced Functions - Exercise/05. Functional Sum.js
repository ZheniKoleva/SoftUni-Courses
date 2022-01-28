function add(number) {
    let result = number;

    const sum = function(n) {
        result += n;
        return sum;
    }

    sum.toString = function() {
        return result;
    }

    return sum;
}

console.log(add(1).toString());
console.log(add(4)(3).toString());
console.log(add(1)(6)(-3).toString());