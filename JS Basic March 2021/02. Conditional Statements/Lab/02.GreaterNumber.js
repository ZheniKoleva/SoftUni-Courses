function greaterNumber(input) {
    let isBigger = input[0] > input[1] ? console.log(input[0]) : console.log(input[1]);
}
greaterNumber(["5", "3"]);
greaterNumber(["3", "5"]);
greaterNumber(["10", "10"]);
greaterNumber(["-5", "5"]);