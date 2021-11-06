function trainigLab(input) {
    let labLenght = Number(input[0]);
    let labWidth = Number(input[1]);

    const aisle = 1.00;
    const workPlacesTaken = 3;
    let widthOfWorkPlace = 0.70;
    let lenghtOfWorkPlace = 1.20;

    let rows = Math.trunc(labLenght / lenghtOfWorkPlace);
    let columns = Math.trunc((labWidth - aisle) / widthOfWorkPlace);

    let seats = (rows * columns) - workPlacesTaken;
    console.log(seats);
}
trainigLab(["15", "8.9"]);
trainigLab(["8.4", "5.2"]);