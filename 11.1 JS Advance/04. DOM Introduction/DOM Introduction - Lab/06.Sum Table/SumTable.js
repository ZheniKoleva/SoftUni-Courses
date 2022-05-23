function sumTable() {
    let tableElements = Array.from(document.querySelectorAll('table tbody tr td'))
        .filter((x, i) => i % 2 == 1);

    let sumElement = tableElements.pop();
    let sum = 0;

    for (const row of tableElements) {
        sum += Number(row.textContent);
    }

    sumElement.textContent = sum;
}