function attachEventsListeners() {
    const ratios = {
        km: 1000,
        m: 1,
        cm: 0.01,
        mm: 0.001,
        mi: 1609.34,
        yrd: 0.9144,
        ft: 0.3048,
        in: 0.0254
    };

    document.querySelector('#convert')
        .addEventListener('click', convertData);

    function convertData(e) {
        const parent = e.target.parentElement;
        const inputDimession = parent.querySelector('#inputUnits').value;
        const inputValue = parent.querySelector('#inputDistance').value;
        const outputDimmesion = document.querySelector('#outputUnits').value;

        const inMeteres = inputValue * ratios[inputDimession];

        const outputValue = inMeteres / ratios[outputDimmesion];

        document.querySelector('#outputDistance').value = outputValue;
    }
}