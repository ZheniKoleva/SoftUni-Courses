function fishTank(input) {
    let lenght = Number(input[0]);
    let width = Number(input[1]);
    let height = Number(input[2]);
    let percentTaken = Number(input[3]);

    let fishtankVolume = (lenght * width * height) / 1000;
    fishtankVolume -= fishtankVolume * (percentTaken / 100);
    console.log(fishtankVolume);
}
fishTank(["85", "75", "47", "17"]);
fishTank(["105", "77", "89", "18.5"]);