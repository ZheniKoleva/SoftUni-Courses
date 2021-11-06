function password(input) {
    let index = 0;
    let userName = input[index++];
    let password = input[index++];
    let currentPassword = input[index++];

    while (currentPassword !== password) {
        currentPassword = input[index++];
    }

    console.log(`Welcome ${userName}!`)
}
password(["Nakov",
"1234",
"Pass",
"1324",
"1234"]);

console.log(`-----------------`);
password(["Gosho",
"secret",
"secret"]);

