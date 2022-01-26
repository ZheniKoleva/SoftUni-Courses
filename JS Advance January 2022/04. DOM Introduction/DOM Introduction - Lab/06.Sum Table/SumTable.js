function sumTable() {
    const prices = Array
        .from(document.querySelectorAll('td:nth-of-type(2)'));

    const resultElement = prices.pop();
    const totalPrice = prices.reduce((a, b) => a + Number(b.textContent), 0);
    resultElement.textContent = totalPrice;
}