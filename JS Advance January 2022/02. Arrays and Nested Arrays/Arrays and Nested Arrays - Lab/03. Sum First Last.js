function sumFirstLast(input){
    return  Number(input.shift()) + Number(input.pop());
}

console.log(sumFirstLast(['20', '30', '40']));
console.log(sumFirstLast(['5', '10']));