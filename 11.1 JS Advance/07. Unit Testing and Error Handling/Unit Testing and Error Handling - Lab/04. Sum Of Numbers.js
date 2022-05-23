function sum(arr) {
    let sum = 0;
    for (let num of arr){
        sum += Number(num);
    }
    return sum;
}

module.exports = sum;

console.log(sum([1, 2, 3]));
console.log(sum([-5, -6, -1]));
console.log(sum([]));
