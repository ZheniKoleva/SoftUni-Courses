function attachEventsListeners() {
    const multipliers = {
        days: 1,
        hours: 24,
        minutes: 1440,
        seconds: 86400
    };

    document.querySelector('main')
        .addEventListener('click', convertData);

    function convertData(e) {
        if (e.target.tagName == 'INPUT' && e.target.type == 'button') {
            const parent = e.target.parentElement;
            const inputDimension = parent.querySelector('input[type="text"]').id;
            const inputValue = Number(parent.querySelector('input[type="text"]').value);

            let inDays = inputValue / multipliers[inputDimension];

            const result = Object.fromEntries(Object.entries(multipliers)
                .map(([key, value]) => [key, inDays * multipliers[key]]));

            Array.from(document.querySelectorAll('div input[type="text"]'))
                .forEach(el => el.value = result[el.id]);
        }
    }    
}