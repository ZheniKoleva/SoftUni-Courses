function solve() {
    document.querySelector('#searchBtn').addEventListener('click', onClick);

    function onClick() {
        const searchElement = document.querySelector('#searchField');
        const searchedText = searchElement.value.toLowerCase();
        const rows = Array.from(document.querySelectorAll('tbody tr'));

        rows.forEach(row => {
            const rowColumns = Array.from(row.children)
                .map(x => x.textContent.toLowerCase());

            if (rowColumns.some(c => c.includes(searchedText))) {
                row.classList.add('select');
            } else {
                row.classList.remove('select');
            }
        });

        searchElement.value = '';
    }
}