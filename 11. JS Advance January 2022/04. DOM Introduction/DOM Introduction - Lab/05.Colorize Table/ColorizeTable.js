function colorize() {
    let rowsToColor = Array
        .from(document.querySelectorAll('table tr:nth-of-type(2n)'));

    rowsToColor.forEach(x => x.style.background = 'Teal');
}