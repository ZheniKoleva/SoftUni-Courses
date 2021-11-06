function vacationBookList(input) {
    let bookPagesCount = Number(input[0]);
    let pagesPerHour = Number(input[1]);
    let daysCount = Number(input[2]);

    let totalHourPerBook = bookPagesCount / pagesPerHour;
    let hoursPerDay = totalHourPerBook / daysCount;

    console.log(hoursPerDay);
}
vacationBookList(["212", "20", "2"]);
vacationBookList(["432", "15", "4"]);