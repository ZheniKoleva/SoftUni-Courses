function getInfo() {
    const inputField = document.querySelector('#stopId');    
    const stopNameElement = document.querySelector('#stopName');
    const ulElement = document.querySelector('#buses');
    const busId = inputField.value;    
    ulElement.replaceChildren();

    const url = `http://localhost:3030/jsonstore/bus/businfo/${busId}`

    fetch(url)
        .then(response => validateResponse(response))
        .then(data => visualizeData(data))
        .catch(error => stopNameElement.textContent = `Error`);

    function validateResponse(response) {
        if (response.status != 200) {
            throw new Error();
        }

        return response.json();
    }

    function visualizeData(data) {
        stopNameElement.textContent = data.name;
        Object.keys(data.buses)
            .forEach(x => {
                const liElement = document.createElement('li');
                liElement.textContent = `Bus ${x} arrives in ${data.buses[x]} minutes`;

                ulElement.appendChild(liElement);
            });

        inputField.value = '';
    }    
}